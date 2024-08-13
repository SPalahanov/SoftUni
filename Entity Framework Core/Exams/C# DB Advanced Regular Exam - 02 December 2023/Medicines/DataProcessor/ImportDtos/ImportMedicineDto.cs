using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Medicine))]
    public class ImportMedicineDto
    {
        [XmlElement(nameof(Name))]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Price))]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; } 

        [XmlElement(nameof(ProductionDate))]
        public string ProductionDate { get; set; } = null!;

        [XmlElement(nameof(ExpiryDate))]
        public string ExpiryDate { get; set; } = null!;

        [XmlElement(nameof(Producer))]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;

        [XmlAttribute("category")]
        [Range(0, 4)]
        public int Category { get; set; }
    }
}
