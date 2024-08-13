using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

using static Trucks.Data.DataConstraints;

namespace Trucks.Data.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }

        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [StringLength(TruckVinNumberLength)]
        public string VinNumber { get; set; } = null!;

        [Range(TruckTankCapacityMinValue, TruckTankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [Range(TruckCargoCapacityMinValue, TruckCargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } =
            new HashSet<ClientTruck>();
    }
}
