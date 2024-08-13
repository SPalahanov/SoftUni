using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;

        }
        
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public string Size { get; private set; }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Small")
                {
                    price = 1.0 / 3 * value;
                }
                else if (Size == "Middle")
                {
                    price = 2.0 / 3 * value;
                }
                else if (Size == "Large")
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
