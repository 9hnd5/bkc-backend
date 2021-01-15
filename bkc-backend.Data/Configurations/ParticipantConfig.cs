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
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property<string>(x => x.PickupLocationId);
            builder.Property<string>(x => x.EmployeeId);
            builder.Property<string>(x => x.EmployeeName);
            builder.Property<string>(x => x.EmployeePhone);
            builder.Property<string>(x => x.EmployeeEmail);
        }
    }
}
