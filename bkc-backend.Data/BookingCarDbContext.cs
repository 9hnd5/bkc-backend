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
            builder.ApplyConfiguration(new TicketConfig());
            builder.ApplyConfiguration(new CarConfig());
            builder.ApplyConfiguration(new DriverConfig());
            builder.ApplyConfiguration(new ParticipantConfig());
            builder.ApplyConfiguration(new LocationConfig());
            builder.ApplyConfiguration(new RelatePersonConfig());
            builder.ApplyConfiguration(new TripConfig());
            builder.ApplyConfiguration(new TicketTripConfig());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RelatedPeople> RelatedPeoples { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TicketTrip> TicketTrips { get; set; }

    }
}
