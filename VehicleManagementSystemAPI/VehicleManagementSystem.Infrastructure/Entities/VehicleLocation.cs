using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleManagementSystem.Infrastructure.Entities
{
    public class VehicleLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VehicleLocationId { get; set; }

        public Guid VehicleId { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; }

    }
}
