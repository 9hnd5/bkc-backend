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
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("BKC_Location");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.Place).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.Time).HasColumnType("nvarchar(15)");
            builder.Property<string>(x => x.GuestName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.Phone).HasColumnType("nvarchar(15)");
            builder.Property<string>(x => x.Note).HasColumnType("nvarchar(100)");
            builder.Property<int>(x => x.TicketId);
            builder.Ignore(x => x.Participants);
            builder.Ignore(x => x.Ticket);
        }
    }
}
