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
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("BKC_Ticket");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).ValueGeneratedOnAdd();
            builder.Property<string>(x => x.EmployeeId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeLineManagerId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeeLineManagerName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.EmployeePhone).HasColumnType("nvarchar(15)");
            builder.Property<string>(x => x.EmployeeBuId).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.EmployeeBuName).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.EmployeeDepartment).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.CreateDate).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.StartDate).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.EndDate).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.FromLocation).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.ToLocation).HasColumnType("nvarchar(100)");
            builder.Property<int>(x => x.TotalParticipant);
            builder.Property<string>(x => x.ReasonBooking).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.ApproverName).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.ApproverId).HasColumnType("nvarchar(30)");
            builder.Property<string>(x => x.ApprovedDate).HasColumnType("nvarchar(20)");
            builder.Property<string>(x => x.ReasonReject).HasColumnType("nvarchar(100)");
            builder.Property<string>(x => x.Status).HasColumnType("nvarchar(10)");

            builder.Ignore(x => x.Locations);
            builder.Ignore(x => x.RelatedPeoples);

            builder.Ignore(x => x.TicketTrips);
        }
    }
}
