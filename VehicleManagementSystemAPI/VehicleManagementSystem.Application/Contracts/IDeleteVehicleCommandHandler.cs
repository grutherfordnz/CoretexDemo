using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManagementSystem.Application.Contracts
{
    public interface IDeleteVehicleCommandHandler
    {
        bool DeleteVehicle(Guid vehicleId);
    }
}
