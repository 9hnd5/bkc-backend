using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("BKC_Trip");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<bool>(x => x.IsFinish);
            builder.Property<string>(x => x.StartDate).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.FromLocation).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.ToLocation).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.Type).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.NoteForDriver).HasColumnType("nvarchar(100)");

            builder.Property<int>(x => x.CarId);
            builder.Ignore(x => x.Car);

            builder.Property<int>(x => x.DriverId);
            builder.Ignore(x => x.Driver);

            builder.Ignore(x => x.TicketTrips);
        }
    }
}
