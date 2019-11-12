using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WiscoIpsum.Migrations
{
    public partial class AddCacheSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "DataCache",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(449)", nullable: false),
                Value = table.Column<byte[]>(type:"varbinary(max)", nullable: false),
                ExpiresAtTime = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable:false),
                SlidingExpirationInSeconds = table.Column<long>(type: "bigint", nullable: true),
                AbsoluteExpiration = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DataCache", x => x.Id);
            });

            migrationBuilder.CreateIndex(name: "Index_ExpiresAtTime", table: "DataCache", column: "ExpiresAtTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "Index_ExpiresAtTime");
            migrationBuilder.DropTable(name: "DataCache");
        }
    }
}
