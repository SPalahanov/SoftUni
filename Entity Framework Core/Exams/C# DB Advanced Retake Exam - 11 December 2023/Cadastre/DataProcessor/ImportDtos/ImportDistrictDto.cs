using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(DistrictNameMinLength)]
        [MaxLength(DistrictNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("PostalCode")]
        [Required]
        [RegularExpression(DistrictPostalCodeRegex)]
        public string PostalCode { get; set; } = null!;

        

        [XmlArray("Properties")]
        public ImportPropertyDto[] Properties { get; set; } = null!;


        [XmlAttribute("Region")]
        [Required]
        public string Region { get; set; } = null!;
    }
}
