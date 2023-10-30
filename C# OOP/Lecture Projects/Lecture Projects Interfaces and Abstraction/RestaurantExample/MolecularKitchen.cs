using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantExample.Contracts;

namespace RestaurantExample
{
    internal class MolecularKitchen : IOrderTaker
    {
        public void TakeOrder(string order)
        {
            Console.WriteLine($"Preparing {order}");
            Console.WriteLine($"{order} disappeared");
        }
    }
}
