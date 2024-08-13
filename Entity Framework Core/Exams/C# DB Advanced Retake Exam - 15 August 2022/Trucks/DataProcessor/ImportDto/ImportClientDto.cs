using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models;

using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ClientNationalityMinLength)]
        [MaxLength(ClientNationalityMaxLength)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TrucksId { get; set; } = null!;
    }
}
