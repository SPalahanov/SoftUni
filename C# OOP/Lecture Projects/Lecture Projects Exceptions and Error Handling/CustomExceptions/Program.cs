namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EmployeeException ex = new EmployeeException("Name not valid");

                ex.Employee = new Employee("Pesho");

                throw ex;
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Employee is {ex.Employee.Name}");

                throw;
            }
        }
    }
}