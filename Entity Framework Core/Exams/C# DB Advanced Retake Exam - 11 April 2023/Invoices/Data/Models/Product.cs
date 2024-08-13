using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Invoices.Data.DataConstraints;

namespace Invoices.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required] // decimal ist Required by default
        public decimal Price { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; } //Enumeration is stored in the DB as INT -> by defaul is Required

        public virtual ICollection<ProductClient> ProductsClients { get; set; } 
            = new HashSet<ProductClient>();
    }
}
