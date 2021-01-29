using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class RoleUserConfig : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.ToTable("BKC_RoleUser");
            builder.HasKey(e => e.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<int>(e => e.RoleId);
            builder.Property<string>(e => e.EmployeeId).HasColumnType("nvarchar(100)");
            builder.Property<string>(e => e.EmployeeBuId).HasColumnType("nvarchar(100)");
            builder.Ignore(x => x.Role);
            builder.HasData(
                new RoleUser { Id = 1, RoleId = 1, EmployeeId = "102144", EmployeeBuId = "300000001732966" },
                new RoleUser { Id = 2, RoleId = 1, EmployeeId = "104077", EmployeeBuId = "300000001732966" },
                new RoleUser { Id = 3, RoleId = 1, EmployeeId = "602748", EmployeeBuId = "300000001732979" }
            );
        }
    }
}
