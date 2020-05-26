using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManagementSystem.Infrastructure.DbContexts
{
    public class DesignTimeVehicleDbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
    {
        private const string DefaultConfigurationFilePath = "appsettings.json";

        public VehicleDbContext CreateDbContext(string[] args)
        {
            return new VehicleDbContext(
                new DbContextOptionsBuilder<VehicleDbContext>()
                    .UseSqlServer(
                        GetConnectionString(),
                        options =>
                            options.MigrationsHistoryTable(
                                "__EFMigrationsHistory",
                                VehicleDbContext.DefaultSchema))
                    .Options);
        }

        private string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder();
            var configuration = configBuilder
                .AddJsonFile(
                    path: DefaultConfigurationFilePath,
                    optional: false,
                    reloadOnChange: true)
                .Build();
            var connectionString = configuration
                .GetConnectionString(VehicleDbContext.DefaultConnectionStringName);

            return !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : "Data Source=localhost;Initial Catalog=vehicleManagementSystemDbLocal;Integrated Security=True;";
        }
    }
}
