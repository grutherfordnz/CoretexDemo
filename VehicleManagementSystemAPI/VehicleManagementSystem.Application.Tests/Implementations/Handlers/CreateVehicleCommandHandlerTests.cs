using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementSystem.Application.Implementations.Handlers;
using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Tests.Implementations.Handlers
{
    [TestClass]
    public class CreateVehicleCommandHandlerTests
    {
        private Mock<IVehicleRepository> _vehicleRepositoryMock;
        private CreateVehicleCommandHandler _createVehicleCommandHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleRepositoryMock.Setup(x => x.CreateVehicle(It.IsAny<Vehicle>()));
            _createVehicleCommandHandler = new CreateVehicleCommandHandler(
                _vehicleRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateVehicle_SuccessfullySendsNewVehicleToRepository()
        {
            var newVehicle = new CreateVehicleCommandParameter(
                "Test Vehicle",
                50,
                123.32,
                23.4,
                66,
                54.67,
                30);

            var newId = _createVehicleCommandHandler.CreateVehicle(newVehicle);

            _vehicleRepositoryMock.Verify(x => x.CreateVehicle(It.Is<Vehicle>(x =>
                x.VehicleId == newId &&
                x.Name == newVehicle.Name &&
                x.Speed == newVehicle.Speed &&
                x.Latitude == newVehicle.Latitude &&
                x.Longitude == newVehicle.Longitude &&
                x.EngineTemperature == newVehicle.EngineTemperature &&
                x.RadiatorPressure == newVehicle.RadiatorPressure &&
                x.FuelRemaining == newVehicle.FuelRemaining)), Times.Once());

            newId.Should().NotBeNull();
            newId.Should().NotBeEmpty();
        }

        [TestMethod]
        public void CreateVehicle_ReturnsNullForInvalidFields()
        {
            var newVehicle = new CreateVehicleCommandParameter(
                null,
                50,
                123.32,
                23.4,
                66,
                54.67,
                30);

            var newId = _createVehicleCommandHandler.CreateVehicle(newVehicle);
            newId.Should().BeNull();

            newVehicle = new CreateVehicleCommandParameter(
                "Test Vehicle",
                50,
                123.32,
                23.4,
                -1,
                54.67,
                30);
            newId = _createVehicleCommandHandler.CreateVehicle(newVehicle);
            newId.Should().BeNull();

            newVehicle = new CreateVehicleCommandParameter(
                "Test Vehicle",
                50,
                123.32,
                23.4,
                66,
                -54.67,
                30);
            newId = _createVehicleCommandHandler.CreateVehicle(newVehicle);
            newId.Should().BeNull();

            newVehicle = new CreateVehicleCommandParameter(
                "Test Vehicle",
                50,
                123.32,
                23.4,
                66,
                54.67,
                -3);
            newId = _createVehicleCommandHandler.CreateVehicle(newVehicle);
            newId.Should().BeNull();

            _vehicleRepositoryMock.Verify(x => x.CreateVehicle(It.IsAny<Vehicle>()), Times.Never());
        }
    }
}
