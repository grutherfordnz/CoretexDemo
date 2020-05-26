using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManagementSystem.Contract.Parameters
{
    public class CreateVehicleApiParameters
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double EngineTemperature { get; set; }
        public double RadiatorPressure { get; set; }
        public int FuelRemaining { get; set; }
    }
}
