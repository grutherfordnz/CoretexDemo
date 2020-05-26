using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManagementSystem.Infrastructure.Migrations
{
    public partial class RemovingVehicleLocationUpdatedAddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleLocation_VehicleId",
                schema: "vehicle",
                table: "VehicleLocation");

            migrationBuilder.DropColumn(
                name: "UpdatedTimestamp",
                schema: "vehicle",
                table: "VehicleLocation");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimestamp",
                schema: "vehicle",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "vehicle",
                table: "Vehicle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocation_VehicleId",
                schema: "vehicle",
                table: "VehicleLocation",
                column: "VehicleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleLocation_VehicleId",
                schema: "vehicle",
                table: "VehicleLocation");

            migrationBuilder.DropColumn(
                name: "DeletedTimestamp",
                schema: "vehicle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "vehicle",
                table: "Vehicle");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTimestamp",
                schema: "vehicle",
                table: "VehicleLocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocation_VehicleId",
                schema: "vehicle",
                table: "VehicleLocation",
                column: "VehicleId");
        }
    }
}
