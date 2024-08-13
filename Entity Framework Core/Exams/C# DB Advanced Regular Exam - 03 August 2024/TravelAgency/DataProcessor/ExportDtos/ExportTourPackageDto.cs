using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("TourPackage")]
    public class ExportTourPackageDto
    {
        [Required]
        [MinLength(TourPackageNameMinLength)]
        [MaxLength(TourPackageNameMaxLength)]
        [XmlElement("Name")]
        public string PackageName { get; set; } = null!;

        [MaxLength(TourPackageDescriptionMaxLength)]
        [XmlElement("Description")]
        public string Description { get; set; } = null!;

        [Required]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
