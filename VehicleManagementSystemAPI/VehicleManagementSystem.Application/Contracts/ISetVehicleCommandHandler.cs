using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Application.Implementations.Results;

namespace VehicleManagementSystem.Application.Contracts
{
    public interface ISetVehicleCommandHandler
    {
        bool UpdateVehicle(UpdateVehicleCommandParameter updateVehiclesCommandParameters);
    }
}
