namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!"); 
            //The amount of money John has – floating - point number in the range[0.00…1000.00].
            //The count of students – integer in the range[0…100].
            //The price of lightsabers for a single saber – floating - point number in the range[0.00…100.00].
            //The price of robes for a single robe – floating - point number in the range[0.00…100.00].
            //The price of belts for a single belt – floating - point number in the range[0.00…100.00].

            double budget = double.Parse(Console.ReadLine());
            int countOfStudent = int.Parse(Console.ReadLine());
            double sabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double freeBelts = countOfStudent / 6;

            double total = sabersPrice * Math.Ceiling(countOfStudent + countOfStudent * 0.1) + robesPrice * (countOfStudent) + beltPrice * (countOfStudent - freeBelts);

            if (total <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(budget - total):f2}lv more.");
            }
        }
    }
}