using Microsoft.EntityFrameworkCore.Migrations;

namespace WiscoIpsum.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Phrase",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Ope" },
                    { 2, "Where-Abouts" },
                    { 3, "Spotted Cow" },
                    { 4, "Brandy Old Fashioned" },
                    { 5, "Stop-and-go-lights" },
                    { 6, "Fleet Farm" },
                    { 7, "Cheesehead" },
                    { 8, "Fish Fry" },
                    { 9, "Bubbler" },
                    { 10, "Aw Geez" },
                    { 11, "For Cripes Sakes" },
                    { 12, "Up Nort" },
                    { 13, "Uff-Da" },
                    { 14, "Ya Know?" },
                    { 15, "Believe You Me" },
                    { 16, "You betcha" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
