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
    public class PickupLocationConfig : IEntityTypeConfiguration<PickupLocation>
    {
        public void Configure(EntityTypeBuilder<PickupLocation> builder)
        {
            builder.ToTable("BKC_PickupLocation");
            builder.HasKey(x => x.Id);
            builder.Property<string>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.BookingInforId);
            builder.Property<string>(x => x.Location);
            builder.Property<string>(x => x.Time);
            builder.Property<string>(x => x.Guest);
            builder.Property<string>(x => x.Phone);
            builder.Property<string>(x => x.Note);
            builder.Ignore(x => x.BookingInfor);
            builder.Ignore(x => x.Participants);
        }
    }
}
