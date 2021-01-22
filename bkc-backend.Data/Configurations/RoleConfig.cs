using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("BKC_Role");
            builder.HasKey(r => r.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(r => r.Name).HasColumnType("nvarchar(30)");
            builder.Ignore(x => x.RoleUser);
            builder.HasData(new Role { Id = 2, Name = "Admin" }, new Role { Id = 3, Name = "Member" }, new Role {Id=1, Name="SuperAdmin" });
        }
    }
}
