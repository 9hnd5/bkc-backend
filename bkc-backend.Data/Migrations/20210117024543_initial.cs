using Microsoft.EntityFrameworkCore.Migrations;

namespace bkc_backend.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BKC_BookingInfor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLineManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLineManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeBuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeBuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPerson = table.Column<int>(type: "int", nullable: false),
                    ReasonBooking = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_BookingInfor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_BookingResult",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingInforId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovingTripId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturningTripId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_BookingResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Car",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeat = table.Column<int>(type: "int", nullable: false),
                    AvailableSeat = table.Column<int>(type: "int", nullable: false),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Driver",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Participant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickupLocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_PickupLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingInforId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_PickupLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_RelatePerson",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingInforId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_RelatePerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_RoleUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeBuId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_RoleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Trip",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Trip", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BKC_Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2", "Admin" },
                    { "3", "Member" },
                    { "1", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "BKC_RoleUser",
                columns: new[] { "Id", "EmployeeBuId", "EmployeeId", "EmployeeName", "RoleId" },
                values: new object[,]
                {
                    { "1", "300000001732966", "102144", null, "1" },
                    { "2", "300000001732966", "104077", null, "3" },
                    { "3", "300000001732979", "602748", null, "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BKC_BookingInfor");

            migrationBuilder.DropTable(
                name: "BKC_BookingResult");

            migrationBuilder.DropTable(
                name: "BKC_Car");

            migrationBuilder.DropTable(
                name: "BKC_Driver");

            migrationBuilder.DropTable(
                name: "BKC_Participant");

            migrationBuilder.DropTable(
                name: "BKC_PickupLocation");

            migrationBuilder.DropTable(
                name: "BKC_RelatePerson");

            migrationBuilder.DropTable(
                name: "BKC_Role");

            migrationBuilder.DropTable(
                name: "BKC_RoleUser");

            migrationBuilder.DropTable(
                name: "BKC_Trip");
        }
    }
}
