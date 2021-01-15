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
    public class BookingResultConfig : IEntityTypeConfiguration<BookingResult>
    {
        public void Configure(EntityTypeBuilder<BookingResult> builder)
        {
            builder.ToTable("BKC_BookingResult");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property<string>(x => x.BookingInforId);
            builder.Property<string>(x => x.MovingTripId);
            builder.Property<string>(x => x.ReturningTripId);
            builder.Property<string>(x => x.Status);

        }
    }
}
