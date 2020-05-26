using System;
using System.Collections.Generic;
using VehicleManagementSystem.Application.Implementations.Results;

namespace VehicleManagementSystem.Application.Contracts
{
    public interface IGetVehiclesQueryHandler
    {
        GetVehicleQueryResult[] GetVehicles();
    }
}
