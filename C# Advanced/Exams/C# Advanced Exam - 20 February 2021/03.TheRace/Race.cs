using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Data { get; set; }

        public void Add(Racer Racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(Racer);
            }
        }

        public bool Remove(string name) => Data.Remove(Data.FirstOrDefault(d => d.Name == name));

        //=============.net 6===========//
        public Racer GetOldestRacer() => Data.FirstOrDefault(Data.MaxBy(d => d.Age));

        //===========.net 3.1===========//

        //public Racer GetOldestRacer()
        //{
        //    Racer oldestRacer = null;
        //    int maxAge = 0;

        //    foreach (Racer racer in Data)
        //    {
        //        if (racer.Age > maxAge)
        //        {
        //            maxAge = racer.Age;
        //            oldestRacer = racer;
        //        }
        //    }
        //    return oldestRacer;
        //}



        //=============.net 6===========//
        public Racer GetRacer(string name) => Data.FirstOrDefault(d => d.Name == name);

        public Racer GetFastestRacer() => Data.FirstOrDefault(Data.MinBy(d => d.Car.Speed));

        //===========.net 3.1===========//

        //public Racer GetFastestRacer()
        //{
        //    Racer fastestRacer = null;
        //    int maxSpeed = 0;
        //    foreach (var racer in Data)
        //    {
        //        if (racer.Car.Speed > maxSpeed)
        //        {
        //            maxSpeed = racer.Car.Speed;
        //            fastestRacer = racer;
        //        }
        //    }
        //    return fastestRacer;

        //}

        public int Count => Data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}");

            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
