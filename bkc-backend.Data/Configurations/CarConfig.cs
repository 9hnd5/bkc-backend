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
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("BKC_Car");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.Number).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.CurrentLocation).HasColumnType("nvarchar(100)");
            builder.Property<int>(x => x.TotalSeat);
            builder.Property<int>(x => x.AvailableSeat);
            builder.Property<string>(x => x.BuId).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.BuName).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.Status);
            builder.Property<bool>(x => x.IsBooked);
            builder.Property<string>(x => x.Manufactured);
            builder.Property<string>(x => x.Name);
            builder.Ignore(x => x.Driver);
            //builder.HasData(new Car()
            //{
            //    Id = 1001,
            //    AvailableSeat =12,
            //    BuId = "300000001732966",
            //    BuName = "H.O",
            //    Number = "GOLD-XYZZ11",
            //    Status = false,
            //    TotalSeat = 12
            //},
            //new Car()
            //{
            //    Id = 1002,
            //    AvailableSeat = 7,
            //    BuId = "300000001732966",
            //    BuName = "H.O",
            //    Number = "GOLD-9X11232",
            //    Status = false,
            //    TotalSeat = 7
            //},
            //new Car()
            //{
            //    Id = 1003,
            //    AvailableSeat = 14,
            //    BuId = "300000001732966",
            //    BuName = "H.O",
            //    Number = "GOLD-9X27363",
            //    Status = false,
            //    TotalSeat = 14
            //}
            //);
        }
    }
}
