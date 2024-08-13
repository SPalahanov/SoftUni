using System.ComponentModel.DataAnnotations;

using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CustomerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(CustomerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } =
            new HashSet<Booking>();
    }
}
