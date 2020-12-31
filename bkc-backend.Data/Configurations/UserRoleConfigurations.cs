using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("BkcUserRole");
            builder.HasKey(e => e.Id);
            builder.Property<string>(e => e.RoleId);
            builder.Property<string>(e => e.EmployeeId);
            builder.Property<string>(e => e.BusinessUnitId);
            builder.HasData(
                new UserRole { Id = "1", RoleId = "1", EmployeeId = "100001", BusinessUnitId = "300000001732966" },
                new UserRole { Id = "2", RoleId = "2", EmployeeId = "100002", BusinessUnitId = "300000001732966" },
                new UserRole { Id = "3", RoleId = "2", EmployeeId = "100005", BusinessUnitId = "300000001732966" },
                new UserRole { Id = "4", RoleId = "1", EmployeeId = "100009", BusinessUnitId = "300000001732979" },
                new UserRole { Id = "5", RoleId = "2", EmployeeId = "100010", BusinessUnitId = "300000001732979" }
            );
        }
    }
}
