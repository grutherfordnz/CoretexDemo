using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Application.Implementations.Results;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Implementations.Handlers
{
    public class SetVehicleCommandHandler : ISetVehicleCommandHandler
    {
        private readonly IVehicleRepository _vehicleRepository;

        public SetVehicleCommandHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        public bool UpdateVehicle(
            UpdateVehicleCommandParameter updateVehiclesCommandParameters)
        {
            if (updateVehiclesCommandParameters.Speed < 0)
            {
                return false;
            }
            if (updateVehiclesCommandParameters.EngineTemperature < 0)
            {
                return false;
            }
            if (updateVehiclesCommandParameters.RadiatorPressure < 0)
            {
                return false;
            }
            if (updateVehiclesCommandParameters.FuelRemaining < 0)
            {
                return false;
            } 

            var updatedVehicle = new Vehicle(
                updateVehiclesCommandParameters.VehicleId,
                updateVehiclesCommandParameters.Speed,
                updateVehiclesCommandParameters.Latitude,
                updateVehiclesCommandParameters.Longitude,
                updateVehiclesCommandParameters.EngineTemperature,
                updateVehiclesCommandParameters.RadiatorPressure,
                updateVehiclesCommandParameters.FuelRemaining);

            try
            {
                _vehicleRepository.UpdateVehicle(updatedVehicle);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
