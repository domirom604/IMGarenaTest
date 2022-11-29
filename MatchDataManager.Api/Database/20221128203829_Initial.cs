using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchDataManager.Api.Database
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 55, nullable: true),
                    YearOFPublish = table.Column<string>(type: "TEXT", maxLength: 5, nullable: true),
                    CityOfPublish = table.Column<string>(type: "TEXT", maxLength: 55, nullable: true),
                    IdKey = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookTable",
                columns: new[] { "Id", "Author", "BookName", "CityOfPublish", "IdKey", "YearOFPublish" },
                values: new object[] { new Guid("9d2b0228-4d0d-4c23-8b49-01a698857799"), "Alan Walk", "New Story Book", "Gliwice", 1, "2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTable");
        }
    }
}
