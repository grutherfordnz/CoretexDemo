using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManagementSystem.Infrastructure.Migrations
{
    public partial class RemovingVehicleLocationCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                schema: "vehicle",
                table: "VehicleLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTimestamp",
                schema: "vehicle",
                table: "VehicleLocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
