using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class BookingInforConfigurations : IEntityTypeConfiguration<BookingInfor>
    {
        public void Configure(EntityTypeBuilder<BookingInfor> builder)
        {
            builder.ToTable("BkcBookingInfor");
            builder.HasKey(i => i.Id);
            builder.Property<string>(i => i.MoveDate);
            builder.Property<string>(i => i.ReturnDate);
            builder.Property<string>(i => i.Location);
            builder.Property<string>(i => i.Destination);
            builder.Property<int>(i => i.TotalPerson);
            builder.Property<int>(i => i.BookerId);
            builder.Property<string>(i => i.ReasonBooking);
            
        }
    }
}
