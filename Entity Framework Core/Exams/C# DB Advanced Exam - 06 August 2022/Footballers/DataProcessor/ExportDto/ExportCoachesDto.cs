using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static Footballers.Data.DataConstraints;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachesDto
    {
        [Required]
        [MinLength(CoachNameMinLength)]
        [MaxLength(CoachNameMaxLength)]
        [XmlElement("CoachName")]
        public string Name { get; set; } = null!;

        [XmlArray("Footballers")]
        public ExportFootballerDto[] Footballers { get; set; } = null!;

        [XmlAttribute("FootballersCount")]
        [Required]
        public int FootballersCount { get; set; }
    }
}
