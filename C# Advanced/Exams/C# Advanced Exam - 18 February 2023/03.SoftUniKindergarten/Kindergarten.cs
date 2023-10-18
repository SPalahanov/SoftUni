using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; private set; }

        public List<Child> Registry { get; private set; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            if (Registry.Contains(Registry.FirstOrDefault(ch =>
                    (ch.FirstName + " " + ch.LastName) == childFullName)))
            {
                return Registry.Remove(Registry.FirstOrDefault(ch =>
                    (ch.FirstName + " " + ch.LastName) == childFullName));
            }

            return false;
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            if (Registry.Contains(Registry.FirstOrDefault(ch =>
                    (ch.FirstName + " " + ch.LastName) == childFullName)))
            {
                return Registry.FirstOrDefault(ch =>
                    (ch.FirstName + " " + ch.LastName) == childFullName);
            }

            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(a =>a.Age).ThenBy(ln => ln.LastName).ThenBy(fn => fn.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
