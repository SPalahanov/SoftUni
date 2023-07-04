namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(" -> ");

                string companyName = arguments[0];
                string companyId = arguments[1];
                
                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }

                if (companies[companyName].Contains(companyId))
                {
                    continue;
                }
                else
                {
                    companies[companyName].Add(companyId);
                }
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}