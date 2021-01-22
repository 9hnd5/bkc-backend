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
    public class TicketTripConfig : IEntityTypeConfiguration<TicketTrip>
    {
        public void Configure(EntityTypeBuilder<TicketTrip> builder)
        {
            builder.ToTable("BKC_TicketTrip");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<int>(x => x.TicketId);
            builder.Property<int>(x => x.TripId);
            builder.Ignore(x => x.Ticket);
            builder.Ignore(x => x.Trip);
        }
    }
}
