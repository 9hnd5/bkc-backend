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
    public class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("BKC_Driver");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.EmployeeId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeePhone).HasColumnType("nvarchar(15)");
            builder.Property<string>(x => x.EmployeeEmail).HasColumnType("nvarchar(50)");
            builder.Property<string>(x => x.EmployeeBuId).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.EmployeeBuName).HasColumnType("nvarchar(100)");
            builder.Property<int>(x => x.CarId);
            builder.Ignore(x => x.Car);
            //builder.HasData(new Driver()
            //{
            //    Id = 2001,
            //    EmployeeId = "602748",
            //    EmployeeName = "Nguyễn Văn Tài",
            //    EmployeePhone = "0934773645",
            //    EmployeeEmail = "abc@gmail.com",
            //    EmployeeBuId = "300000001732966",
            //    EmployeeBuName = "H.O",
            //    CarId = 1001
            //},
            //new Driver()
            //{
            //    Id = 2002,
            //    EmployeeId = "102144",
            //    EmployeeEmail = "abc@gmail.com",
            //    EmployeeName = "Trần Văn Cường",
            //    EmployeePhone = "0334773235",
            //    EmployeeBuId = "300000001732966",
            //    EmployeeBuName = "H.O",
            //    CarId = 1002
            //},
            //new Driver()
            //{
            //    Id = 2003,
            //    EmployeeId = "104077",
            //    EmployeeEmail = "abc@gmail.com",
            //    EmployeeName = "Nguyễn Thị Hoa",
            //    EmployeePhone = "0884773235",
            //    EmployeeBuId = "300000001732966",
            //    EmployeeBuName = "H.O",
            //    CarId = 1003
            //}
            //);
        }
    }
}
