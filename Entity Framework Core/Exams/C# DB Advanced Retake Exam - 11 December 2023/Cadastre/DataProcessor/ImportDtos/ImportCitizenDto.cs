using Cadastre.Data.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [Required]
        [MinLength(CitizenFirstNameMinLength)]
        [MaxLength(CitizenFirstNameMaxLength)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(CitizenLastNameMinLength)]
        [MaxLength(CitizenLastNameMaxLength)]
        [JsonProperty("LastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        [JsonProperty("MaritalStatus")]
        public string MaritalStatus { get; set; } = null!;

        [JsonProperty("Properties")]
        public int[] PropertiesId { get; set; } = null!;
    }
}
