using Cadastre.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlType("Property")]
    public class ExportPropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [MinLength(PropertyIdentifierMinLength)]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        [Required]
        [Range(PropertyAreaMinValue, PropertyAreaMaxValue)]
        public int Area { get; set; }

        [XmlElement("DateOfAcquisition")]
        public string DateOfAcquisition { get; set; } = null!;

        [XmlAttribute("postal-code")]
        [Required]
        public string PostalCode { get; set; } = null!;
    }
}
