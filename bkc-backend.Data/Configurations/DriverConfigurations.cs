using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class DriverConfigurations : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("BkcDriver");
            builder.HasKey(d => d.Id);
            builder.Property<string>(d => d.Name);
            builder.Property<string>(d => d.Phone);
            builder.Property<string>(d => d.Email);
            builder.HasData(
                new Driver()
                {
                    Id="2001",
                    Email="hanv@greenfeed.com.vn",
                    Name="Nguyễn Văn Hạ",
                    Phone="093422345"
                },
                new Driver()
                {
                    Id = "2002",
                    Email = "lamnv@greenfeed.com.vn",
                    Name = "Nguyễn Văn Lâm",
                    Phone = "093422335"
                },
                new Driver()
                {
                    Id = "2003",
                    Email = "cuongtv@greenfeed.com.vn",
                    Name = "Trần Văn Cường",
                    Phone = "033422335"
                },
                new Driver()
                 {
                     Id = "2004",
                     Email = "tientv@greenfeed.com.vn",
                     Name = "Trần Văn Tiến",
                     Phone = "056422335"
                 },
                new Driver()
                  {
                      Id = "2005",
                      Email = "xuanln@greenfeed.com.vn",
                      Name = "Lâm Nguyễn Xuân",
                      Phone = "099422335"
                  },
                new Driver()
                   {
                       Id = "2006",
                       Email = "tuongnx@greenfeed.com.vn",
                       Name = "Nguyễn Xuân Tường",
                       Phone = "011422335"
                   },
                new Driver()
                   {
                       Id = "2007",
                       Email = "namnt@greenfeed.com.vn",
                       Name = "Nguyễn Thạch Nam",
                       Phone = "088422335"
                   }
            );
        }
    }
}
