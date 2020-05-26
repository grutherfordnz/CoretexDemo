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
    public class GetVehiclesQueryHandlerTests
    {
        private Mock<IVehicleRepository> _vehicleRepositoryMock;
        private GetVehiclesQueryHandler _getVehiclesQueryHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleRepositoryMock.Setup(x => x.GetVehicles());
            _getVehiclesQueryHandler = new GetVehiclesQueryHandler(
                _vehicleRepositoryMock.Object);
        }

        [TestMethod]
        public void GetVehicles_SuccessfullyReturnsAllVehicles()
        {
            _vehicleRepositoryMock.Setup(x => x.GetVehicles())
                .Returns(() =>
                {
                    return new Vehicle[]
                    {
                        new Vehicle(Guid.NewGuid(), "Testing", 100, 34.43, 65.23, 122.3, 55, 4, DateTime.UtcNow, DateTime.UtcNow),
                        new Vehicle(Guid.NewGuid(), "Testing", 100, 34.43, 65.23, 122.3, 55, 4, DateTime.UtcNow, DateTime.UtcNow),
                        new Vehicle(Guid.NewGuid(), "Testing", 100, 34.43, 65.23, 122.3, 55, 4, DateTime.UtcNow, DateTime.UtcNow),
                        new Vehicle(Guid.NewGuid(), "Testing", 100, 34.43, 65.23, 122.3, 55, 4, DateTime.UtcNow, DateTime.UtcNow)
                    };
                });

            var vehicles = _getVehiclesQueryHandler.GetVehicles();

            vehicles.Should().NotBeNull();
            vehicles.Should().NotBeEmpty();
            vehicles.Should().HaveCount(4);
        }

        [TestMethod]
        public void GetVehicles_SuccessfullyReturnsNoVehicles()
        {
            _vehicleRepositoryMock.Setup(x => x.GetVehicles())
                .Returns(() =>
                {
                    return new Vehicle[0];
                });

            var vehicles = _getVehiclesQueryHandler.GetVehicles();

            vehicles.Should().NotBeNull();
            vehicles.Should().BeEmpty();
        }
    }
}