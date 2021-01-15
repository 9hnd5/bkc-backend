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
    public class RelatePersonConfig : IEntityTypeConfiguration<RelatePerson>
    {
        public void Configure(EntityTypeBuilder<RelatePerson> builder)
        {
            builder.ToTable("BKC_RelatePerson");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property<string>(x => x.BookingInforId);
            builder.Property<string>(x => x.EmployeeId);
            builder.Property<string>(x => x.EmployeeName);
            builder.Property<string>(x => x.EmployeeEmail);
        }
    }
}
