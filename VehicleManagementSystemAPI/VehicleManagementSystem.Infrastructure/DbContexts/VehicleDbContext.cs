using Microsoft.EntityFrameworkCore;
using System.Linq;
using VehicleManagementSystem.Infrastructure.Entities;

namespace VehicleManagementSystem.Infrastructure.DbContexts
{
    public class VehicleDbContext : DbContext
    {
        public const string DefaultSchema = "vehicle";
        public const string DefaultConnectionStringName = "VehicleManagementSystemConnectionString";

        public VehicleDbContext(DbContextOptions<VehicleDbContext> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<VehicleLocation> VehicleLocation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);

            base.OnModelCreating(modelBuilder);
        }
    }
}
