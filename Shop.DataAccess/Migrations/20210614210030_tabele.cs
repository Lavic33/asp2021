using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAccess.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Brends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Brends",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Brends",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brends",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Brends",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Brends");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Brends");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Brends");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brends");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Brends");
        }
    }
}
