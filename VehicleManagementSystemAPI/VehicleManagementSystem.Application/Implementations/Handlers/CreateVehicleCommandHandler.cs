using System;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Implementations.Handlers
{
    public class CreateVehicleCommandHandler : ICreateVehicleCommandHandler
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleCommandHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Guid? CreateVehicle(CreateVehicleCommandParameter createVehicleCommandParameter)
        {
            if (string.IsNullOrWhiteSpace(createVehicleCommandParameter.Name))
            {
                return null;
            }
            if (createVehicleCommandParameter.Speed < 0)
            {
                return null;
            }
            if (createVehicleCommandParameter.EngineTemperature < 0)
            {
                return null;
            }
            if (createVehicleCommandParameter.RadiatorPressure < 0)
            {
                return null;
            }
            if (createVehicleCommandParameter.FuelRemaining < 0)
            {
                return null;
            }

            var newVehicle = Vehicle.CreateNew(
                createVehicleCommandParameter.Name,
                createVehicleCommandParameter.Speed,
                createVehicleCommandParameter.Latitude,
                createVehicleCommandParameter.Longitude,
                createVehicleCommandParameter.EngineTemperature,
                createVehicleCommandParameter.RadiatorPressure,
                createVehicleCommandParameter.FuelRemaining);
            try
            {
                _vehicleRepository.CreateVehicle(newVehicle);
            }
            catch (Exception e)
            {
                return null;
            }

            return newVehicle.VehicleId;
        }
    }
}
