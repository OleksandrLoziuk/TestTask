using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.API.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Sum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orers",
                columns: new[] { "Id", "Name", "Sum" },
                values: new object[] { 1, "Order1", 50.0 });

            migrationBuilder.InsertData(
                table: "Orers",
                columns: new[] { "Id", "Name", "Sum" },
                values: new object[] { 2, "Order2", 100.0 });

            migrationBuilder.InsertData(
                table: "Orers",
                columns: new[] { "Id", "Name", "Sum" },
                values: new object[] { 3, "Order3", 200.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
