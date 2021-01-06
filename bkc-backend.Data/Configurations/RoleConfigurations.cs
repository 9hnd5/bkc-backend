using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("BkcRole");
            builder.HasKey(r => r.Id);
            builder.Property<string>(r => r.RoleName);
            builder.HasData(new Role { Id = 1, RoleName = "Admin" }, new Role { Id = 2, RoleName = "Employee" });
        }
    }
}
