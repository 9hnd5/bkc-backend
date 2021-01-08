using Microsoft.EntityFrameworkCore.Migrations;

namespace bkc_backend.Data.Migrations
{
    public partial class DBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BkcBooker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineManagerId = table.Column<int>(type: "int", nullable: false),
                    LineManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBooker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcBookingInfor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookerId = table.Column<int>(type: "int", nullable: false),
                    MoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPerson = table.Column<int>(type: "int", nullable: false),
                    ReasonBooking = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBookingInfor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcBookingParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingPickupLocationId = table.Column<int>(type: "int", nullable: false),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBookingParticipant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcBookingPickupLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookerId = table.Column<int>(type: "int", nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    NoteByBooker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcBookingPickupLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeat = table.Column<int>(type: "int", nullable: false),
                    AvailableSeat = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcCar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcDriver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcRoleUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BuId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcRoleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BkcTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerId = table.Column<int>(type: "int", nullable: false),
                    BookerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    MoveTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkcTrip", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BkcCar",
                columns: new[] { "Id", "AvailableSeat", "BuId", "BuName", "DriverId", "Number", "Status", "TotalSeat" },
                values: new object[,]
                {
                    { 1001, 12, "300000001732966", "Head Office", 2001, "GOLD-9X001", "Free", 12 },
                    { 1002, 10, "300000001732966", "Head Office", 2002, "GOLD-8X001", "Free", 10 },
                    { 1003, 7, "300000001732966", "Head Office", 2003, "GOLD-7X001", "Free", 7 },
                    { 1004, 4, "300000001732966", "Head Office", 2004, "GOLD-6X001", "Free", 4 },
                    { 1005, 5, "300000001732979", "Projects", 2005, "GOLD-5X001", "Free", 5 },
                    { 1006, 6, "300000001732979", "Projects", 2006, "GOLD-4X001", "Free", 6 },
                    { 1007, 12, "300000001732979", "Projects", 2007, "GOLD-3X001", "Free", 12 }
                });

            migrationBuilder.InsertData(
                table: "BkcDriver",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 2007, "namnt@greenfeed.com.vn", "Nguyễn Thạch Nam", 88422335 },
                    { 2006, "tuongnx@greenfeed.com.vn", "Nguyễn Xuân Tường", 11422335 },
                    { 2005, "xuanln@greenfeed.com.vn", "Lâm Nguyễn Xuân", 99422335 },
                    { 2004, "tientv@greenfeed.com.vn", "Trần Văn Tiến", 56422335 },
                    { 2003, "cuongtv@greenfeed.com.vn", "Trần Văn Cường", 33422335 },
                    { 2002, "lamnv@greenfeed.com.vn", "Nguyễn Văn Lâm", 93422335 },
                    { 2001, "hanv@greenfeed.com.vn", "Nguyễn Văn Hạ", 93422345 }
                });

            migrationBuilder.InsertData(
                table: "BkcRole",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 2, "Admin" },
                    { 3, "Employee" },
                    { 1, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "BkcRoleUser",
                columns: new[] { "Id", "BuId", "EmployeeId", "RoleId" },
                values: new object[,]
                {
                    { 1, "300000001732966", 100001, 1 },
                    { 2, "300000001732966", 100002, 2 },
                    { 3, "300000001732966", 100005, 2 },
                    { 4, "300000001732979", 100009, 1 },
                    { 5, "300000001732979", 100010, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BkcBooker");

            migrationBuilder.DropTable(
                name: "BkcBookingInfor");

            migrationBuilder.DropTable(
                name: "BkcBookingParticipant");

            migrationBuilder.DropTable(
                name: "BkcBookingPickupLocation");

            migrationBuilder.DropTable(
                name: "BkcCar");

            migrationBuilder.DropTable(
                name: "BkcDriver");

            migrationBuilder.DropTable(
                name: "BkcRole");

            migrationBuilder.DropTable(
                name: "BkcRoleUser");

            migrationBuilder.DropTable(
                name: "BkcTrip");
        }
    }
}
