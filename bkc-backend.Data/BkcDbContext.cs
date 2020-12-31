using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Configurations;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace bkc_backend.Data
{
    public class BkcDbContext: DbContext
    {
        public BkcDbContext(DbContextOptions option): base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookingInforConfigurations());
            builder.ApplyConfiguration(new CarConfigurations());
            builder.ApplyConfiguration(new DriverConfigurations());
            builder.ApplyConfiguration(new BookingDetailConfigurations());
            builder.ApplyConfiguration(new RoleConfigurations());
            builder.ApplyConfiguration(new UserRoleConfigurations());
            builder.ApplyConfiguration(new BookerConfigurations());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booker> Bookers { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<BookingInfor> BookingInfors { get; set; }
    }
}
