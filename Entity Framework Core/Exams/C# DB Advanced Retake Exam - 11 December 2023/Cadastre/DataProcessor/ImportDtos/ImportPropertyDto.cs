using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportPropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [MinLength(PropertyIdentifierMinLength)]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        [Required]
        [Range(PropertyAreaMinValue, PropertyAreaMaxValue)]
        public int Area { get; set; }

        [XmlElement("Details")]
        [MinLength(PropertyDetailsMinLength)]
        [MaxLength(PropertyDetailsMaxLength)]
        public string Details { get; set; } = null!;

        [XmlElement("Address")]
        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        [Required]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
