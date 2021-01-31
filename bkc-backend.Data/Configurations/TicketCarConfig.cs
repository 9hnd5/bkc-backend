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
    public class TicketCarConfig : IEntityTypeConfiguration<TicketCar>
    {
        public void Configure(EntityTypeBuilder<TicketCar> builder)
        {
            builder.ToTable("BKC_TicketCar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsFinish);
            builder.Property(x => x.Type).HasColumnType("nvarchar(40)");
            builder.Property(x => x.StartDate).HasColumnType("nvarchar(20)");
            builder.Property(x => x.EndDate).HasColumnType("nvarchar(20)");
            builder.Property(x => x.NoteForDriver).HasColumnType("nvarchar(200)");

            builder.Property(x => x.TicketId);
            builder.Ignore(x => x.Ticket);

            builder.Property(x => x.CarId);
            builder.Ignore(x => x.Car);
        }
    }
}
