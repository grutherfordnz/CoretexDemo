using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Implementations.Results;
using VehicleManagementSystem.Application.Repositories;

namespace VehicleManagementSystem.Application.Implementations.Handlers
{
    public class GetVehiclesQueryHandler : IGetVehiclesQueryHandler
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesQueryHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        public GetVehicleQueryResult GetVehicleById(Guid vehicleId)
        {
            throw new NotImplementedException();
        }

        public GetVehicleQueryResult[] GetVehicles()
        {
            var vehicles = _vehicleRepository.GetVehicles();
            return vehicles.Select(v =>
                new GetVehicleQueryResult(
                    v.VehicleId,
                    v.Name,
                    v.Speed,
                    v.Latitude,
                    v.Longitude,
                    v.EngineTemperature,
                    v.RadiatorPressure,
                    v.FuelRemaining,
                    v.UpdatedTimestamp.Value,
                    v.CreatedTimestamp.Value))
                .ToArray();
        }
    }
}
