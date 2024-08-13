using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Artillery.Data.DataConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [Required]
        [Range(ShellWeightMinValue, ShellWeightMaxValue)]
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(ShellCaliberMinLength)]
        [MaxLength(ShellCaliberMaxLength)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; } = null!;
    }
}
