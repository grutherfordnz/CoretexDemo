using System;
using Microsoft.EntityFrameworkCore.Migrations;
using VehicleManagementSystem.Infrastructure.Entities;

namespace VehicleManagementSystem.Infrastructure.Migrations
{
    public partial class InitialVehicleState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vehicle");

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    EngineTemperature = table.Column<double>(nullable: false),
                    RadiatorPressure = table.Column<double>(nullable: false),
                    FuelRemaining = table.Column<int>(nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocation",
                schema: "vehicle",
                columns: table => new
                {
                    VehicleLocationId = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocation", x => x.VehicleLocationId);
                    table.ForeignKey(
                        name: "FK_VehicleLocation_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "vehicle",
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocation_VehicleId",
                schema: "vehicle",
                table: "VehicleLocation",
                column: "VehicleId");

            SeedData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleLocation",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "vehicle");
        }

        private Vehicle GetVehicle()
        {
            var createdAt = DateTime.UtcNow;

            return new Vehicle()
            {
                VehicleId = Guid.NewGuid(),
                Name = "Mercedes-Benz Actros",
                Speed = 60,
                EngineTemperature = 80,
                RadiatorPressure = 20,
                FuelRemaining = 40,
                CreatedTimestamp = createdAt,
                UpdatedTimestamp = createdAt
            };
        }

        private VehicleLocation GetVehicleLocation(Guid vehicleId)
        {
            return new VehicleLocation()
            {
                VehicleLocationId = Guid.NewGuid(),
                VehicleId = vehicleId,
                Latitude = 156.5346,
                Longitude = 144.2322
            };
        }

        private void SeedData(MigrationBuilder migrationBuilder)
        {
            var vehicle = GetVehicle();
            var vehicleLocation = GetVehicleLocation(vehicle.VehicleId);

            migrationBuilder.Sql(@$"
                Insert Into vehicle.Vehicle 
                (
                    VehicleId, 
                    Name, 
                    Speed, 
                    EngineTemperature, 
                    RadiatorPressure, 
                    FuelRemaining, 
                    CreatedTimestamp, 
                    UpdatedTimestamp
                )
                Values 
                (
                    '{vehicle.VehicleId}', 
                    '{vehicle.Name}', 
                    {vehicle.Speed}, 
                    {vehicle.EngineTemperature}, 
                    {vehicle.RadiatorPressure}, 
                    {vehicle.FuelRemaining}, 
                    '{vehicle.UpdatedTimestamp}'
                    '{vehicle.CreatedTimestamp}', 
                )"
            );

            migrationBuilder.Sql(@$"
                Insert Into vehicle.VehicleLocation 
                (
                    VehicleLocationId, 
                    VehicleId, 
                    Latitude, 
                    Longitude
                )
                Values 
                (
                    '{vehicleLocation.VehicleLocationId}', 
                    '{vehicleLocation.VehicleId}', 
                    {vehicleLocation.Latitude}, 
                    {vehicleLocation.Longitude}
                )"
            );
        }
    }
}
