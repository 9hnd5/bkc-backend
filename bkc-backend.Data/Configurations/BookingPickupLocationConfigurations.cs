using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class BookingPickupLocationConfigurations : IEntityTypeConfiguration<BookingPickupLocation>
    {
        public void Configure(EntityTypeBuilder<BookingPickupLocation> builder)
        {
            builder.ToTable("BkcBookingPickupLocation");
            builder.HasKey(d => d.Id);
            builder.Property<string>(d => d.PickupLocation);
            builder.Property<string>(d => d.PickupTime);
            builder.Property<int>(d => d.EmployeeId);
            builder.Property<string>(d => d.EmployeeName);
            builder.Property<string>(d => d.GuestName);
            builder.Property<int>(d => d.Phone);
            builder.Property<string>(d => d.NoteByBooker);
            builder.Property<string>(d => d.NoteByAdmin);
            builder.Property<int>(d => d.BookerId);
        }
    }
}
