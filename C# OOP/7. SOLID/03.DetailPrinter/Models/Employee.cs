namespace DetailPrinter.Models
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Employee {Name}";
        }
    }
}
