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
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property<string>(x => x.DriverId);
            builder.Property<string>(x => x.Number);
            builder.Property<int>(x => x.TotalSeat);
            builder.Property<int>(x => x.AvailableSeat);
            builder.Property<string>(x => x.BuId);
            builder.Property<string>(x => x.BuName);
            builder.Property<bool>(x => x.Status);
        }
    }
}
