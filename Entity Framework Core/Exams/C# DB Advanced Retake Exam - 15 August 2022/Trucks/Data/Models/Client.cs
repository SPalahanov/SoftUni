using System.ComponentModel.DataAnnotations;

using static Trucks.Data.DataConstraints;

namespace Trucks.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } =
            new HashSet<ClientTruck>();
    }
}
