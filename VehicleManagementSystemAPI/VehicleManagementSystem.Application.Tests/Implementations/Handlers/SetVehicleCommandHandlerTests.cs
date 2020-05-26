using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VehicleManagementSystem.Application.Implementations.Handlers;
using VehicleManagementSystem.Application.Implementations.Parameters;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Tests.Implementations.Handlers
{
    [TestClass]
    public class SetVehicleCommandHandlerTests
    {
        private Mock<IVehicleRepository> _vehicleRepositoryMock;
        private SetVehicleCommandHandler _setVehicleCommandHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _setVehicleCommandHandler = new SetVehicleCommandHandler(
                _vehicleRepositoryMock.Object);
        }

        [TestMethod]
        public void UpdateVehicle_SuccessfullyUpdatesVehicleInRepository()
        {
            var updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                50,
                123.32,
                23.4,
                66,
                54.67,
                30);

            var isSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);

            _vehicleRepositoryMock.Verify(x => x.UpdateVehicle(It.Is<Vehicle>(x =>
                x.VehicleId == updatedVehicle.VehicleId &&
                x.Speed == updatedVehicle.Speed &&
                x.Latitude == updatedVehicle.Latitude &&
                x.Longitude == updatedVehicle.Longitude &&
                x.EngineTemperature == updatedVehicle.EngineTemperature &&
                x.RadiatorPressure == updatedVehicle.RadiatorPressure &&
                x.FuelRemaining == updatedVehicle.FuelRemaining)), Times.Once());

            isSuccessful.Should().BeTrue();
        }

        [TestMethod]
        public void UpdateVehicle_ReturnsFalseForInvalidFields()
        {
            var updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                -1,
                123.32,
                23.4,
                66,
                54.67,
                30);

            var isSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);
            isSuccessful.Should().BeFalse();

            updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                50,
                123.32,
                23.4,
                -1,
                54.67,
                30);

            isSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);
            isSuccessful.Should().BeFalse();

            updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                50,
                123.32,
                23.4,
                66,
                -54.67,
                30);
            isSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);
            isSuccessful.Should().BeFalse();

            updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                -50,
                123.32,
                23.4,
                66,
                54.67,
                -3);
            isSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);
            isSuccessful.Should().BeFalse();

            _vehicleRepositoryMock.Verify(x => x.UpdateVehicle(It.IsAny<Vehicle>()), Times.Never());
        }

        [TestMethod]
        public void UpdateVehicle_ReturnsFalseIfExceptionIsThrownFromRepository()
        {
            var updatedVehicle = new UpdateVehicleCommandParameter(
                Guid.NewGuid(),
                50,
                123.32,
                23.4,
                66,
                54.67,
                30);

            _vehicleRepositoryMock.Setup(x => x.UpdateVehicle(It.IsAny<Vehicle>()))
                .Callback<Vehicle>(x =>
                {
                    throw new ArgumentException();
                });

            var updateSuccessful = _setVehicleCommandHandler.UpdateVehicle(updatedVehicle);

            _vehicleRepositoryMock.Verify(x => x.UpdateVehicle(It.IsAny<Vehicle>()), Times.Once());
            updateSuccessful.Should().BeFalse();
        }
    }
}
