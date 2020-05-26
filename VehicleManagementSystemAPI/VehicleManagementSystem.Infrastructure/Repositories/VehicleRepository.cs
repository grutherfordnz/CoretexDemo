using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Infrastructure.DbContexts;
using VehicleManagementSystem.Infrastructure.Entities;
using DomainVehicle = VehicleManagementSystem.Domain.Vehicle;

namespace VehicleManagementSystem.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _dbContext;

        public VehicleRepository(
            VehicleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DomainVehicle[] GetVehicles()
        {
            var vehicles = _dbContext.Vehicle
                .Include(x => x.VehicleLocation)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedTimestamp);

            return vehicles.Select(v =>
                new DomainVehicle(
                    v.VehicleId,
                    v.Name,
                    v.Speed,
                    v.VehicleLocation.Latitude,
                    v.VehicleLocation.Longitude,
                    v.EngineTemperature,
                    v.RadiatorPressure,
                    v.FuelRemaining,
                    v.UpdatedTimestamp,
                    v.CreatedTimestamp))
                .ToArray();
        }

        public void CreateVehicle(DomainVehicle newVehicle)
        {
            var createdAt = DateTime.UtcNow;

            var vehicle = new Vehicle()
            {
                VehicleId = newVehicle.VehicleId,
                Name = newVehicle.Name,
                Speed = newVehicle.Speed,
                EngineTemperature = newVehicle.EngineTemperature,
                RadiatorPressure = newVehicle.RadiatorPressure,
                FuelRemaining = newVehicle.FuelRemaining,
                CreatedTimestamp = createdAt,
                UpdatedTimestamp = createdAt,
                VehicleLocation = new VehicleLocation()
                {
                    VehicleLocationId = Guid.NewGuid(),
                    Latitude = newVehicle.Latitude,
                    Longitude = newVehicle.Longitude
                }
            };

            _dbContext.Vehicle.Add(vehicle);

            _dbContext.SaveChanges();
        }

        public void UpdateVehicle(DomainVehicle updatedVehicle)
        {
            var vehicleToUpdate = _dbContext.Vehicle
                .Include(x => x.VehicleLocation)
                .Single(x => x.VehicleId == updatedVehicle.VehicleId);

            vehicleToUpdate.Speed = updatedVehicle.Speed;
            vehicleToUpdate.EngineTemperature = updatedVehicle.EngineTemperature;
            vehicleToUpdate.RadiatorPressure = updatedVehicle.RadiatorPressure;
            vehicleToUpdate.FuelRemaining = updatedVehicle.FuelRemaining;
            vehicleToUpdate.UpdatedTimestamp = DateTime.UtcNow;
            vehicleToUpdate.VehicleLocation.Latitude = updatedVehicle.Latitude;
            vehicleToUpdate.VehicleLocation.Longitude = updatedVehicle.Longitude;

            _dbContext.SaveChanges();
        }

        public int GetVehicleCount()
        {
            return _dbContext.Vehicle
                .Where(x => !x.IsDeleted)
                .Count();
        }

        public void DeleteVehicle(Guid vehicleId)
        {
            var vehicleToDelete = _dbContext.Vehicle
                .Single(x => x.VehicleId == vehicleId);

            vehicleToDelete.IsDeleted = true;
            vehicleToDelete.DeletedTimestamp = DateTime.UtcNow;

            _dbContext.SaveChanges();
        }
    }
}
