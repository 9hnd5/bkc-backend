using Microsoft.EntityFrameworkCore.Migrations;

namespace bkc_backend.Data.Migrations
{
    public partial class updatetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BkcBookingDetail",
                table: "BkcBookingDetail");

            migrationBuilder.RenameTable(
                name: "BkcBookingDetail",
                newName: "BkcBookingPickupLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BkcBookingPickupLocation",
                table: "BkcBookingPickupLocation",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BkcBookingPickupLocation",
                table: "BkcBookingPickupLocation");

            migrationBuilder.RenameTable(
                name: "BkcBookingPickupLocation",
                newName: "BkcBookingDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BkcBookingDetail",
                table: "BkcBookingDetail",
                column: "Id");
        }
    }
}
