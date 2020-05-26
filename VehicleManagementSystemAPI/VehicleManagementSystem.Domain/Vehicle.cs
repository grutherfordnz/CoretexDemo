using System;
using System.Linq;

namespace VehicleManagementSystem.Domain
{
    public class Vehicle
    {
        public static Vehicle CreateNew(
            string name,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining)
        {
            return new Vehicle(
                Guid.NewGuid(),
                name,
                speed,
                latitude,
                longitude,
                engineTemperature,
                radiatorPressure,
                fuelRemaining);
        }

        public Vehicle(
            Guid vehicleId,
            string name,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining,
            DateTime updatedTimestamp,
            DateTime createdTimestamp
        )
        {
            VehicleId = vehicleId;
            Name = name;
            Speed = speed;
            Latitude = latitude;
            Longitude = longitude;
            EngineTemperature = engineTemperature;
            FuelRemaining = fuelRemaining;
            RadiatorPressure = radiatorPressure;
            UpdatedTimestamp = updatedTimestamp;
            CreatedTimestamp = createdTimestamp;
        }

        public Vehicle(
            Guid vehicleId,
            string name,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining
        )
        {
            VehicleId = vehicleId;
            Name = name;
            Speed = speed;
            Latitude = latitude;
            Longitude = longitude;
            EngineTemperature = engineTemperature;
            FuelRemaining = fuelRemaining;
            RadiatorPressure = radiatorPressure;
        }

        public Vehicle(
            Guid vehicleId,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining
        )
        {
            VehicleId = vehicleId;
            Speed = speed;
            Latitude = latitude;
            Longitude = longitude;
            EngineTemperature = engineTemperature;
            RadiatorPressure = radiatorPressure;
            FuelRemaining = fuelRemaining;
        }


        public Guid VehicleId { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
    }
}
