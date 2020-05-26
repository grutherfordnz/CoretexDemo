using System;

namespace VehicleManagementSystem.Contract.Results
{
    public class GetVehicleResult
    {
        public GetVehicleResult(
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

        public Guid VehicleId { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
