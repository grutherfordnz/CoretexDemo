using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementSystem.Application.Implementations.Parameters;

namespace VehicleManagementSystem.Application.Contracts
{
    public interface ICreateVehicleCommandHandler
    {
        public Guid? CreateVehicle(CreateVehicleCommandParameter createVehicleCommandParameter);
    }
}
