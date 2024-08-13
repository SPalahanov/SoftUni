using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Artillery.Data.DataConstraints;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportCountryDto
    {
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        [XmlAttribute("Country")]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(CountryArmySizeMinValue, CountryArmySizeMaxValue)]
        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}
