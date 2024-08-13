using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        [Range(PropertyAreaMinValue, PropertyAreaMaxValue)]
        public int Area { get; set; }

        [MaxLength(PropertyDetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public virtual District District { get; set; } = null!;

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } =
            new HashSet<PropertyCitizen>();
    }
}
