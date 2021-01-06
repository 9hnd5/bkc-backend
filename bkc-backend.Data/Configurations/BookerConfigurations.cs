using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class BookerConfigurations : IEntityTypeConfiguration<Booker>
    {
        public void Configure(EntityTypeBuilder<Booker> builder)
        {
            builder.ToTable("BkcBooker");
            builder.HasKey(b => b.Id);
            builder.Property<int>(b => b.Phone);
            builder.Property<int>(b => b.EmployeeId);
            builder.Property<string>(b => b.EmployeeName);
            builder.Property<string>(b => b.Department);
            builder.Property<string>(b => b.BuName);
            builder.Property<string>(b => b.BuId);
            builder.Property<string>(b => b.LineManagerName);
            builder.Property<int>(b => b.LineManagerId);
            
        }
    }
}
