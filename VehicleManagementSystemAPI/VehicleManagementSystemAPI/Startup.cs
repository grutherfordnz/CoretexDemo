using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VehicleManagementSystem.Application.Contracts;
using VehicleManagementSystem.Application.Implementations.Handlers;
using VehicleManagementSystem.Application.Repositories;
using VehicleManagementSystem.Infrastructure.DbContexts;
using VehicleManagementSystem.Infrastructure.Repositories;

namespace VehicleManagementSystemAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public const string DefaultPolicyName = "CoretexDemo";

        private DbContextOptionsBuilder GetDbContextOptionsBuilder(
            DbContextOptionsBuilder contextOptionsBuilder)
        {
            return contextOptionsBuilder.UseSqlServer(
                Configuration.GetConnectionString(VehicleDbContext.DefaultConnectionStringName),
                sqlOptionsBuilder =>
                    sqlOptionsBuilder
                        .EnableRetryOnFailure()
                        .MigrationsHistoryTable("__MigrationHistory", VehicleDbContext.DefaultSchema));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    DefaultPolicyName,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddScoped<IGetVehiclesQueryHandler, GetVehiclesQueryHandler>();
            services.AddScoped<ISetVehicleCommandHandler, SetVehicleCommandHandler>();
            services.AddScoped<IDeleteVehicleCommandHandler, DeleteVehicleCommandHandler>();
            services.AddScoped<ICreateVehicleCommandHandler, CreateVehicleCommandHandler>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddDbContext<VehicleDbContext>(
                optionsBuilder => GetDbContextOptionsBuilder(optionsBuilder));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(DefaultPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
