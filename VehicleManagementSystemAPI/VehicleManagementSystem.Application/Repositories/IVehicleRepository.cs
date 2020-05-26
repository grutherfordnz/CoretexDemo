using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Repositories
{
    public interface IVehicleRepository
    {
        Vehicle[] GetVehicles();

        void CreateVehicle(Vehicle newVehicle);

        void UpdateVehicle(Vehicle updatedVehicle);

        int GetVehicleCount();

        void DeleteVehicle(Guid vehicleId);
    }
}
