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
    public class ParticipantConfig : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("BKC_Participant");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.EmployeeId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeePhone).HasColumnType("nvarchar(15)");
            builder.Property<string>(x => x.EmployeeEmail).HasColumnType("nvarchar(50)");

            builder.Property<int>(x => x.LocationId);
            builder.Ignore(x => x.Location);
        }
    }
}
