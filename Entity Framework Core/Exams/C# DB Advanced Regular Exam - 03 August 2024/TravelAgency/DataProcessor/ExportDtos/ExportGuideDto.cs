using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuideDto
    {
        [Required]
        [MinLength(GuideFullNameMinLength)]
        [MaxLength(GuideFullNameMaxLength)]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [XmlArray("TourPackages")]
        public ExportTourPackageDto[] TourPackages { get; set; } = null!;
    }
}
