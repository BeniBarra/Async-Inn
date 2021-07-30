using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddedRoomAmenitiesAndHotelRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Amenities");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PetFriendly = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.AmenityId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelId",
                table: "HotelRooms",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "RoomAmenities",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Amenities");

            migrationBuilder.AddColumn<int>(
                name: "Layout",
                table: "Amenities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Layout",
                value: 1);
        }
    }
}
