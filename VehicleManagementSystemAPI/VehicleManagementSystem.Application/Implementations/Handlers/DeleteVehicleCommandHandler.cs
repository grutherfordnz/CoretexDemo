using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Repositories;

namespace VehicleManagementSystem.Application.Implementations.Handlers
{
    public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
    {
        private IVehicleRepository _vehicleRepository;
        public DeleteVehicleCommandHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        public bool DeleteVehicle(Guid vehicleId)
        {
            if (_vehicleRepository.GetVehicleCount() <= 1)
            {
                return false;
            }

            try
            {
                _vehicleRepository.DeleteVehicle(vehicleId);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
