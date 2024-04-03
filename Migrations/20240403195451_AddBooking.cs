using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Destinations_ProductId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationId",
                table: "Bookings",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Destinations_DestinationId",
                table: "Bookings",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Destinations_DestinationId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DestinationId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Destinations_ProductId",
                table: "Bookings",
                column: "ProductId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
