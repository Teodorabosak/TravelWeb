using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWeb.Migrations
{
    /// <inheritdoc />
    public partial class CategoryDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Uzmite pauzu od svakodnevnice i zaronite u čarobni svet evropskih gradova uz našu turističku agenciju. Prepustite se avanturi i istražite fascinantnu istoriju, bogatu kulturu i neponovljivu atmosferu nekih od najpoznatijih destinacija u Evropi. Sa našim pažljivo odabranim putovanjima, očekuju vas nezaboravna iskustva i trenuci koji će vas inspirisati i osvežiti. Doživite čaroliju Pariza, osetite duh Rima, prošetajte kroz šarmantne ulice Amsterdama i još mnogo toga. Vaše putovanje počinje ovde!");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");
        }
    }
}
