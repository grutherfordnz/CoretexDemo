using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManagementSystem.Application.Implementations.Parameters
{
    public class CreateVehicleCommandParameter
    {
        public CreateVehicleCommandParameter(
            string name,
            int speed,
            double latitude,
            double longitude,
            double engineTemperature,
            double radiatorPressure,
            int fuelRemaining)
        {
            Name = name;
            Speed = speed;
            Latitude = latitude;
            Longitude = longitude;
            EngineTemperature = engineTemperature;
            RadiatorPressure = radiatorPressure;
            FuelRemaining = fuelRemaining;
        }

        public string Name { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
    }
}
