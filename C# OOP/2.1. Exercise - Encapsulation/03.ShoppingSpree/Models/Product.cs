using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameEmpty);
                }

                name = value;
            }
        }

        public decimal Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyNegative);
                }

                cost = value;
            }
        }
    }
}
