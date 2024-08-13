using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [MaxLength(ValidationConstants.UsersNamesMaxLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.PasswordMaxLength)]
        public string Password { get; set; }

        [MaxLength(ValidationConstants.EmailMaxLength)]
        public string Email { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
