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
    public class RelatePersonConfig : IEntityTypeConfiguration<RelatedPeople>
    {
        public void Configure(EntityTypeBuilder<RelatedPeople> builder)
        {
            builder.ToTable("BKC_RelatedPeople");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.EmployeeId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeEmail).HasColumnType("nvarchar(50)");

            builder.Property<int>(x => x.TicketId);
            builder.Ignore(x => x.Ticket);
        }
    }
}
