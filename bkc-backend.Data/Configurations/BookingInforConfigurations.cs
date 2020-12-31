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
            builder.Property<string>(i => i.PickupTime);
            builder.Property<string>(i => i.ReturnTime);
            builder.Property<string>(i => i.Location);
            builder.Property<string>(i => i.Destination);
            builder.Property<string>(i => i.TotalPerson);
            builder.Property<string>(i => i.BookerId);
            
        }
    }
}
