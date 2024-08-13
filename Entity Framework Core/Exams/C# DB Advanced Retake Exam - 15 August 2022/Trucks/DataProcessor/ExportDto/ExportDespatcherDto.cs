using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;

using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherDto
    {
        [Required]
        [MinLength(DespatcherNameMinLength)]
        [MaxLength(DespatcherNameMaxLength)]
        [XmlElement("DespatcherName")]
        public string Name { get; set; } = null!;

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlArray("Trucks")]
        public ExportTruckDto[] Trucks { get; set; } = null!;
    }
}
