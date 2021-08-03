using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddedNewRoomDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Layout",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Layout",
                value: "2 Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Layout",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Layout",
                value: 1);
        }
    }
}
