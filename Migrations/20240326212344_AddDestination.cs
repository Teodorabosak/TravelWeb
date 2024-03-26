using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Date1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "CategoryId", "Date1", "Date2", "Description", "Hotel", "Name", "Price" },
                values: new object[] { 2, 2, new DateTime(2024, 3, 6, 12, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 29, 0, 50, 0, 0, DateTimeKind.Unspecified), "Uživajte u čarima termalnih kupki, poput čuvenih Gellért kupki, gde možete opustiti tela u toplim izvorima pod elegantnim mozaicima. Za ljubitelje umetnosti, poseta Muzeju savremene umetnosti ili Mađarskoj nacionalnoj galeriji predstavlja priliku da se upoznate sa bogatom kulturnom baštinom grada.  Gurmani će uživati u mađarskoj kuhinji, probajući čuvene gulaše, paprikaš i slatke poslastice poput krempita. Ne zaboravite posetiti Veliko tržište kako biste istražili lokalne proizvode i suvenire.  Budimpešta takođe nudi dinamičan noćni život, sa širokim spektrom barova, klubova i restorana. Šetnja duž obala Dunava noću pruža romantičnu atmosferu, posebno kada su mostovi osvetljeni.", "Sheraton hotel", "Budimpesta", 120.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CategoryId",
                table: "Destinations",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
