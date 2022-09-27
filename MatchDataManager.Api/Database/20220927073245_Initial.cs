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
                name: "LocationTable",
                columns: table => new
                {
                    IdKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 55, nullable: true),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTable", x => x.IdKey);
                });

            migrationBuilder.CreateTable(
                name: "TeamTable",
                columns: table => new
                {
                    IdKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CoachName = table.Column<string>(type: "TEXT", maxLength: 55, nullable: true),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTable", x => x.IdKey);
                });

            migrationBuilder.InsertData(
                table: "LocationTable",
                columns: new[] { "IdKey", "City", "Id", "Name" },
                values: new object[] { 1, "poznan", new Guid("9d2b0228-4d0d-4c23-8b49-01a698857799"), "emi" });

            migrationBuilder.InsertData(
                table: "TeamTable",
                columns: new[] { "IdKey", "CoachName", "Id", "Name" },
                values: new object[] { 1, "elon", new Guid("9d2b0228-4d0d-4c23-8b49-01a698857709"), "domi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationTable");

            migrationBuilder.DropTable(
                name: "TeamTable");
        }
    }
}
