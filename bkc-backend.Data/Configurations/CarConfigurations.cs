using System;
using System.Collections.Generic;
using System.Text;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bkc_backend.Data.Configurations
{
    public class CarConfigurations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("BkcCar");
            builder.HasKey(c => c.Id);
            builder.Property<string>(c => c.Number);
            builder.Property<int>(c => c.TotalSeat);
            builder.Property<int>(c => c.AvailableSeat);
            builder.Property<string>(c => c.Status);
            builder.Property<string>(c => c.BuId);
            builder.Property<string>(c => c.BuName);
            builder.Property<int>(c => c.DriverId);
            builder.HasData(
                    new Car()
                    {
                        Id = 1001,
                        Number = "GOLD-9X001",
                        TotalSeat = 12,
                        AvailableSeat = 12,

                        BuId = "300000001732966",
                        BuName = "Head Office",
                        DriverId = 2001,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1002,
                        Number = "GOLD-8X001",
                        TotalSeat = 10,
                        AvailableSeat = 10,

                        BuId = "300000001732966",
                        BuName = "Head Office",
                        DriverId = 2002,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1003,
                        Number = "GOLD-7X001",
                        TotalSeat = 7,
                        AvailableSeat = 7,

                        BuId = "300000001732966",
                        BuName = "Head Office",
                        DriverId = 2003,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1004,
                        Number = "GOLD-6X001",
                        TotalSeat = 4,
                        AvailableSeat = 4,

                        BuId = "300000001732966",
                        BuName = "Head Office",
                        DriverId = 2004,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1005,
                        Number = "GOLD-5X001",
                        TotalSeat = 5,
                        AvailableSeat = 5,

                        BuId = "300000001732979",
                        BuName = "Projects",
                        DriverId = 2005,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1006,
                        Number = "GOLD-4X001",
                        TotalSeat = 6,
                        AvailableSeat = 6,

                        BuId = "300000001732979",
                        BuName = "Projects",
                        DriverId = 2006,
                        Status = "Free"
                    },
                    new Car()
                    {
                        Id = 1007,
                        Number = "GOLD-3X001",
                        TotalSeat = 12,
                        AvailableSeat = 12,

                        BuId = "300000001732979",
                        BuName = "Projects",
                        DriverId = 2007,
                        Status = "Free"
                    }
                );
        }
    }
}
