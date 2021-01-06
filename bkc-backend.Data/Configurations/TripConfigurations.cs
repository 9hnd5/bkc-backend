using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class TripConfigurations : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("BkcTrip");
            builder.HasKey(t => t.Id);
            builder.Property<string>(t => t.MoveDate);
            builder.Property<string>(t => t.MoveTime);
            builder.Property<string>(t => t.NoteByAdmin);
            builder.Property<string>(t => t.ReturnDate);
            builder.Property<string>(t => t.ReturnTime);
            builder.Property<string>(t => t.DriverName);
            builder.Property<int>(t => t.DriverId);
            builder.Property<int>(t => t.CarId);
            builder.Property<int>(t => t.BookerId);
            builder.Property<string>(t => t.BookerName);
        }
    }
}
