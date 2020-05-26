using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleManagementSystem.Infrastructure.Entities
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VehicleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Speed { get; set; }

        [Required]
        public double EngineTemperature { get; set; }

        [Required]
        public double RadiatorPressure { get; set; }

        [Required]
        public int FuelRemaining { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public DateTime UpdatedTimestamp { get; set; }

        [Required]
        public DateTime CreatedTimestamp { get; set; }

        public DateTime? DeletedTimestamp { get; set; }

        public virtual VehicleLocation VehicleLocation { get; set; }
    }
}
