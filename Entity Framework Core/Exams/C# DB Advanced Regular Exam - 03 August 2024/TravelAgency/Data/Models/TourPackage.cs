using System.ComponentModel.DataAnnotations;

using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TourPackageNameMaxLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(TourPackageDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = 
            new HashSet<Booking>();

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; } =
            new HashSet<TourPackageGuide>();
    }
}
