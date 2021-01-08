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
    public class BookingParticipantConfigurations : IEntityTypeConfiguration<BookingParticipant>
    {

        public void Configure(EntityTypeBuilder<BookingParticipant> builder)
        {
            builder.ToTable("BkcBookingParticipant");
            builder.HasKey(bp => bp.Id);
            builder.Property<int>(bp => bp.EmployeeId);
            builder.Property<string>(bp => bp.EmployeeName);
            builder.Property<string>(bp => bp.BuId);
            builder.Property<string>(bp => bp.BuName);
            builder.Property<int>(bp => bp.BookingPickupLocationId);
        }
    }
}
