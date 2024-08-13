using System.ComponentModel.DataAnnotations;

using static Artillery.Data.DataConstraints;

namespace Artillery.Data.Models
{
    public class Shell
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(ShellWeightMinValue, ShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(ShellCaliberMaxLength)]
        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } =
            new HashSet<Gun>();
    }
}
