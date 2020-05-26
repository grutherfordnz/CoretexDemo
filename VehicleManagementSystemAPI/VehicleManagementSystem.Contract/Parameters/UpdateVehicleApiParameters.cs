namespace VehicleManagementSystem.Contract.Parameters
{
    using System;

    public class UpdateVehicleApiParameters
    {
        public Guid VehicleId { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
    }
}
