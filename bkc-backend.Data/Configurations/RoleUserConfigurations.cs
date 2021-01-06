using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class RoleUserConfigurations : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.ToTable("BkcRoleUser");
            builder.HasKey(e => e.Id);
            builder.Property<int>(e => e.RoleId);
            builder.Property<int>(e => e.EmployeeId);
            builder.Property<string>(e => e.BuId);
            builder.HasData(
                new RoleUser { Id = 1, RoleId = 1, EmployeeId = 100001, BuId = "300000001732966" },
                new RoleUser { Id = 2, RoleId = 2, EmployeeId = 100002, BuId = "300000001732966" },
                new RoleUser { Id = 3, RoleId = 2, EmployeeId = 100005, BuId = "300000001732966" },
                new RoleUser { Id = 4, RoleId = 1, EmployeeId = 100009, BuId = "300000001732979" },
                new RoleUser { Id = 5, RoleId = 2, EmployeeId = 100010, BuId = "300000001732979" }
            );
        }
    }
}
