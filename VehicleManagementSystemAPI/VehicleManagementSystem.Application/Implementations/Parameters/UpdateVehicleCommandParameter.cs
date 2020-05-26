namespace VehicleManagementSystem.Application.Implementations.Parameters
{
    using System;

    public class UpdateVehicleCommandParameter
    {
        public UpdateVehicleCommandParameter(
            Guid vehicleId,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining)
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
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
    }
}
