using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(DespatcherNameMinLength)]
        [MaxLength(DespatcherNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string Position { get; set; } = null!;

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; } = null!;
    }
}
