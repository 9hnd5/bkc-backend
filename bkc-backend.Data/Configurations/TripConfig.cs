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
            builder.Property<string>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.DriverId);
            builder.Property<string>(x => x.CarId);
            builder.Property<string>(x => x.MovingDate);
            builder.Property<string>(x => x.ReturningDate);
            builder.Property<string>(x => x.NoteByAdmin);
            builder.Property<bool>(x => x.Status);
            builder.Ignore(x => x.Car);
            builder.Ignore(x => x.Driver);
            builder.Ignore(x => x.BookingResults);
        }
    }
}
