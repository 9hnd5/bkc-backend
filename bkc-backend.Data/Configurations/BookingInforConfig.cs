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
    public class BookingInforConfig : IEntityTypeConfiguration<BookingInfor>
    {
        public void Configure(EntityTypeBuilder<BookingInfor> builder)
        {
            builder.ToTable("BKC_BookingInfor");
            builder.HasKey(x => x.Id);
            builder.Property<string>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.EmployeeId);
            builder.Property<string>(x => x.EmployeeName);
            builder.Property<string>(x => x.EmployeeLineManagerId);
            builder.Property<string>(x => x.EmployeeLineManagerName);
            builder.Property<string>(x => x.EmployeePhone);
            builder.Property<string>(x => x.EmployeeBuId);
            builder.Property<string>(x => x.EmployeeBuName);
            builder.Property<string>(x => x.EmployeeDepartment);
            builder.Property<string>(x => x.MovingDate);
            builder.Property<string>(x => x.ReturningDate);
            builder.Property<string>(x => x.Location);
            builder.Property<string>(x => x.Destination);
            builder.Property<int>(x => x.TotalPerson);
            builder.Property<string>(x => x.ReasonBooking);
            builder.Ignore(x => x.PickupLocations);
            builder.Ignore(x => x.BookingResult);
            builder.Ignore(x => x.RelatePersons);
        }
    }
}
