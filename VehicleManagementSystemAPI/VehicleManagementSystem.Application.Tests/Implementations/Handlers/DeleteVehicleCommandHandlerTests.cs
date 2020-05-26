using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VehicleManagementSystem.Application.Implementations.Handlers;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Domain;

namespace VehicleManagementSystem.Application.Tests.Implementations.Handlers
{
    [TestClass]
    public class DeleteVehicleCommandHandlerTests
    {
        private Mock<IVehicleRepository> _vehicleRepositoryMock;
        private DeleteVehicleCommandHandler _deleteVehicleCommandHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleRepositoryMock.Setup(x => x.GetVehicleCount())
                .Returns(5);
            _vehicleRepositoryMock.Setup(x => x.DeleteVehicle(It.IsAny<Guid>()));
            _deleteVehicleCommandHandler = new DeleteVehicleCommandHandler(
                _vehicleRepositoryMock.Object);
        }

        [TestMethod]
        public void DeleteVehicle_SuccessfullyCallsRepositoryToDeleteVehicle()
        {
            var vehicleId = Guid.NewGuid();
            var deleteSuccessful = _deleteVehicleCommandHandler.DeleteVehicle(vehicleId);

            _vehicleRepositoryMock.Verify(x => x.DeleteVehicle(It.Is<Guid>(x =>
                x == vehicleId)), Times.Once());

            deleteSuccessful.Should().BeTrue();
        }

        [TestMethod]
        public void DeleteVehicle_FailsToDeleteVehicleWhenTheresNotEnoughVehiclesInDB()
        {
            var vehicleId = Guid.NewGuid();
            _vehicleRepositoryMock.Setup(x => x.GetVehicleCount())
                .Returns(1);

            var deleteSuccessful = _deleteVehicleCommandHandler.DeleteVehicle(vehicleId);

            _vehicleRepositoryMock.Verify(x => x.DeleteVehicle(It.IsAny<Guid>()), Times.Never());
            deleteSuccessful.Should().BeFalse();
        }

        [TestMethod]
        public void DeleteVehicle_ReturnsFalseIfExceptionIsThrownFromRepository()
        {
            var vehicleId = Guid.NewGuid();
            _vehicleRepositoryMock.Setup(x => x.DeleteVehicle(It.IsAny<Guid>()))
                .Callback<Guid>(x =>
                {
                    throw new ArgumentException();
                });

            var deleteSuccessful = _deleteVehicleCommandHandler.DeleteVehicle(vehicleId);

            _vehicleRepositoryMock.Verify(x => x.DeleteVehicle(It.IsAny<Guid>()), Times.Once());
            deleteSuccessful.Should().BeFalse();
        }
    }
}
