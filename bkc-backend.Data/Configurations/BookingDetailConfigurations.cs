using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class BookingDetailConfigurations : IEntityTypeConfiguration<BookingDetail>
    {
        public void Configure(EntityTypeBuilder<BookingDetail> builder)
        {
            builder.ToTable("BkcBookingDetail");
            builder.HasKey(d => d.Id);
            builder.Property<string>(d => d.PickupLocation);
            builder.Property<string>(d => d.PickupTime);
            builder.Property<string>(d => d.EmployeeName);
            builder.Property<string>(d => d.GuestName);
            builder.Property<string>(d => d.Phone);
            builder.Property<string>(d => d.Note);
            builder.Property<string>(d => d.BookerId);
        }
    }
}
