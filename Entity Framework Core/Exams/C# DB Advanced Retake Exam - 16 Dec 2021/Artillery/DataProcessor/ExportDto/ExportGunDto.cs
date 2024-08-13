using Artillery.Data.Models.Enums;
using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Artillery.Data.DataConstraints;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunDto
    {
        [Required]
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [XmlAttribute("GunType")]
        public GunType GunType { get; set; }

        [Required]
        [Range(GunWeightMinValue, GunWeightMaxValue)]
        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [Required]
        [Range(GunBarrelLengthMinValue, GunBarrelLengthMaxValue)]
        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [Required]
        [Range(GunRangeMinValue, GunRangeMaxValue)]
        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public ExportCountryDto[] Countries { get; set; } = null!;
    }
}
