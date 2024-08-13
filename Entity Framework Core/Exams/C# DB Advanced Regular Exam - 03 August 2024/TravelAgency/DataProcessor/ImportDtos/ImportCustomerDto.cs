using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [Required]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        [XmlElement("Email")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(CustomerPhoneNumberRegex)]
        [MaxLength(CustomerPhoneNumberMaxLength)]
        [XmlAttribute("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;
    }
}
