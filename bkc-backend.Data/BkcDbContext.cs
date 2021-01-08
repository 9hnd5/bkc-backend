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
            builder.ApplyConfiguration(new BookingPickupLocationConfigurations());
            builder.ApplyConfiguration(new RoleConfigurations());
            builder.ApplyConfiguration(new RoleUserConfigurations());
            builder.ApplyConfiguration(new BookerConfigurations());
            builder.ApplyConfiguration(new TripConfigurations());
            builder.ApplyConfiguration(new BookingParticipantConfigurations());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booker> Bookers { get; set; }
        public DbSet<BookingPickupLocation> BookingPickupLocations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<BookingInfor> BookingInfors { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<BookingParticipant> bookingParticipants { get; set; }
    }
}
