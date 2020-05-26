using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Contract.Parameters;
using VehicleManagementSystem.Contract.Results;

namespace VehicleManagementSystemAPI.Controllers
{
    [Route("vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IGetVehiclesQueryHandler _getVehiclesQueryHandler;
        private readonly ISetVehicleCommandHandler _setVehiclesCommandHandler;
        private readonly IDeleteVehicleCommandHandler _deleteVehicleCommandHandler;
        private readonly ICreateVehicleCommandHandler _createVehicleCommandHandler;

        public VehicleController(
            IGetVehiclesQueryHandler getVehiclesQueryHandler,
            ISetVehicleCommandHandler setVehiclesCommandHandler,
            IDeleteVehicleCommandHandler deleteVehicleCommandHandler,
            ICreateVehicleCommandHandler createVehicleCommandHandler)
        {
            _getVehiclesQueryHandler = getVehiclesQueryHandler ?? throw new ArgumentNullException(nameof(getVehiclesQueryHandler));
            _setVehiclesCommandHandler = setVehiclesCommandHandler ?? throw new ArgumentNullException(nameof(setVehiclesCommandHandler));
            _deleteVehicleCommandHandler = deleteVehicleCommandHandler ?? throw new ArgumentNullException(nameof(deleteVehicleCommandHandler));
            _createVehicleCommandHandler = createVehicleCommandHandler ?? throw new ArgumentNullException(nameof(createVehicleCommandHandler));
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var vehicles = _getVehiclesQueryHandler.GetVehicles();

            var results = vehicles.Select(v =>
                new GetVehicleResult(
                    v.VehicleId,
                    v.Name,
                    v.Speed,
                    v.Latitude,
                    v.Longitude,
                    v.EngineTemperature,
                    v.RadiatorPressure,
                    v.FuelRemaining,
                    v.UpdatedTimestamp,
                    v.CreatedTimestamp
                )
            );

            return Ok(results);
        }

        [HttpPut]
        public IActionResult UpdateVehicle(UpdateVehicleApiParameters updateVehicleApiParameters)
        {
            var vehicle = new UpdateVehicleCommandParameter(
                updateVehicleApiParameters.VehicleId,
                updateVehicleApiParameters.Speed,
                updateVehicleApiParameters.Latitude,
                updateVehicleApiParameters.Longitude,
                updateVehicleApiParameters.EngineTemperature,
                updateVehicleApiParameters.RadiatorPressure,
                updateVehicleApiParameters.FuelRemaining);

            var isSuccessful = _setVehiclesCommandHandler.UpdateVehicle(vehicle);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{vehicleId:guid}")]
        public IActionResult DeleteVehicle(Guid vehicleId)
        {
            var isSuccessful = _deleteVehicleCommandHandler.DeleteVehicle(vehicleId);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] CreateVehicleApiParameters createVehicleApiParameters)
        {
            var vehicle = new CreateVehicleCommandParameter(
                createVehicleApiParameters.Name,
                createVehicleApiParameters.Speed,
                createVehicleApiParameters.Latitude,
                createVehicleApiParameters.Longitude,
                createVehicleApiParameters.EngineTemperature,
                createVehicleApiParameters.RadiatorPressure,
                createVehicleApiParameters.FuelRemaining);

            var vehicleId = _createVehicleCommandHandler.CreateVehicle(vehicle);

            if (vehicleId == null)
            {
                return BadRequest();
            }

            return Ok(vehicleId);
        }
    }
}
