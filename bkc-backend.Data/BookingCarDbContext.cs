using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Configurations;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace bkc_backend.Data
{
    public class BookingCarDbContext : DbContext
    {
        public BookingCarDbContext(DbContextOptions option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new RoleUserConfig());
            builder.ApplyConfiguration(new BookingInforConfig());
            builder.ApplyConfiguration(new BookingResultConfig());
            builder.ApplyConfiguration(new CarConfig());
            builder.ApplyConfiguration(new DriverConfig());
            builder.ApplyConfiguration(new ParticipantConfig());
            builder.ApplyConfiguration(new PickupLocationConfig());
            builder.ApplyConfiguration(new RelatePersonConfig());
            builder.ApplyConfiguration(new TripConfig());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<BookingInfor> bookingInfors { get; set; }
        public DbSet<BookingResult> bookingResults { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Participant> participants { get; set; }
        public DbSet<PickupLocation> pickupLocations { get; set; }
        public DbSet<RelatePerson> relatePersons { get; set; }
        public DbSet<Trip> trips { get; set; }

    }
}
