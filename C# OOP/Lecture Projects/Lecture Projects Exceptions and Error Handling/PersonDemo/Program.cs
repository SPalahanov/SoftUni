namespace PersonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee = null;

            while (employee == null)
            {
                try
                {
                    employee = new Employee(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again!");
                }
            }
        }
    }

    class Employee
    {
        private string name;

        public Employee(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name should be longer than 1 symbol");
                }

                name = value;
            }
        }
    }
}