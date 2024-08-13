using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Artillery.Data.DataConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; } = null!;

        [Required]
        [XmlElement("ArmySize")]
        [Range(CountryArmySizeMinValue, CountryArmySizeMaxValue)]
        public int ArmySize { get; set; }
    }
}
