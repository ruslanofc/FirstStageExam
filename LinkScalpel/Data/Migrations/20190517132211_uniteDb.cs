using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkScalpel.Data.Migrations
{
    public partial class uniteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountLinks");

            migrationBuilder.DropTable(
                name: "PassLinks");

            migrationBuilder.DropTable(
                name: "TimeLinks");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Links",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Links",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Links",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Links",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Links");

            migrationBuilder.CreateTable(
                name: "CountLinks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassLinks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeLinks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLinks", x => x.Id);
                });
        }
    }
}
