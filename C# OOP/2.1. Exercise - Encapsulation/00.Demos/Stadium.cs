using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public class Stadium
    {
        public List<string> seats;

        public Stadium()
        {
            seats = new List<string>();

            Seats = seats;
        }

        public List<string> Seats
        {
            get => seats; 
            private set => seats = value;
        }

        protected void Add(string seat)
        {
            seats.Add(seat);
        }

        public void Remove(string seat)
        {
            seats.Remove(seat);
        }
    }
}
