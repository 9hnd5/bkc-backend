using Microsoft.EntityFrameworkCore.Migrations;

namespace bkc_backend.Data.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BkcBooker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBooker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcBookingDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBookingDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcBookingInfor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBookingInfor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcCar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableSeat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcCar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcDriver",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcDriver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcUserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcUserRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BkcCar",
                columns: new[] { "Id", "AvailableSeat", "BookerId", "BookingDate", "BuId", "BuName", "DriverId", "Number", "Status", "TotalSeat" },
                values: new object[,]
                {
                    { "1001", "12", "NULL", "NULL", "300000001732966", "Head Office", "2001", "GOLD-9X001", "Free", "12" },
                    { "1002", "10", "NULL", "NULL", "300000001732966", "Head Office", "2002", "GOLD-8X001", "Free", "10" },
                    { "1003", "7", "NULL", "NULL", "300000001732966", "Head Office", "2003", "GOLD-7X001", "Free", "7" },
                    { "1004", "4", "NULL", "NULL", "300000001732966", "Head Office", "2004", "GOLD-6X001", "Free", "4" },
                    { "1005", "5", "NULL", "NULL", "300000001732979", "Projects", "2005", "GOLD-5X001", "Free", "5" },
                    { "1006", "6", "NULL", "NULL", "300000001732979", "Projects", "2006", "GOLD-4X001", "Free", "6" },
                    { "1007", "12", "NULL", "NULL", "300000001732979", "Projects", "2007", "GOLD-3X001", "Free", "12" }
                });

            migrationBuilder.InsertData(
                table: "BkcDriver",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { "2007", "namnt@greenfeed.com.vn", "Nguyễn Thạch Nam", "088422335" },
                    { "2006", "tuongnx@greenfeed.com.vn", "Nguyễn Xuân Tường", "011422335" },
                    { "2005", "xuanln@greenfeed.com.vn", "Lâm Nguyễn Xuân", "099422335" },
                    { "2004", "tientv@greenfeed.com.vn", "Trần Văn Tiến", "056422335" },
                    { "2003", "cuongtv@greenfeed.com.vn", "Trần Văn Cường", "033422335" },
                    { "2002", "lamnv@greenfeed.com.vn", "Nguyễn Văn Lâm", "093422335" },
                    { "2001", "hanv@greenfeed.com.vn", "Nguyễn Văn Hạ", "093422345" }
                });

            migrationBuilder.InsertData(
                table: "BkcRole",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "1", "Admin" },
                    { "2", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "BkcUserRole",
                columns: new[] { "Id", "BusinessUnitId", "EmployeeId", "RoleId" },
                values: new object[,]
                {
                    { "1", "300000001732966", "100001", "1" },
                    { "2", "300000001732966", "100002", "2" },
                    { "3", "300000001732966", "100005", "2" },
                    { "4", "300000001732979", "100009", "1" },
                    { "5", "300000001732979", "100010", "2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BkcBooker");

            migrationBuilder.DropTable(
                name: "BkcBookingDetail");

            migrationBuilder.DropTable(
                name: "BkcBookingInfor");

            migrationBuilder.DropTable(
                name: "BkcCar");

            migrationBuilder.DropTable(
                name: "BkcDriver");

            migrationBuilder.DropTable(
                name: "BkcRole");

            migrationBuilder.DropTable(
                name: "BkcUserRole");
        }
    }
}
