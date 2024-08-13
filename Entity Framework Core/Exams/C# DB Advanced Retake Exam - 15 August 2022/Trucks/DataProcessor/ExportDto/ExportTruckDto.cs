using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;
using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression(TruckRegistrationNumberRegex)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [XmlElement("Make")]
        public MakeType MakeType { get; set; }
    }
}
