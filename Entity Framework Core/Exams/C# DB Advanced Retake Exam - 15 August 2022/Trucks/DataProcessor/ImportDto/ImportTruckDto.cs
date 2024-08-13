using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression(TruckRegistrationNumberRegex)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [StringLength(TruckVinNumberLength)]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;

        [Range(TruckTankCapacityMinValue, TruckTankCapacityMaxValue)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [Range(TruckCargoCapacityMinValue, TruckCargoCapacityMaxValue)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}
