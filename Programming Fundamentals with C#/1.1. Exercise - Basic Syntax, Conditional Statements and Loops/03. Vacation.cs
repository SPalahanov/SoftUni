namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            if (dayOfWeek == "Friday")
            {
                if (groupType == "Students")
                {
                    if (countOfPeople >= 30)
                    {
                        price = (countOfPeople * 8.45) - (countOfPeople * 8.45 * 0.15);
                    }
                    else
                    {
                        price = countOfPeople * 8.45;
                    }
                }
                else if (groupType == "Business")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 10.90 - (10 * 10.90);
                    }
                    else
                    {
                        price = countOfPeople * 10.90;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price = (countOfPeople * 15) - (countOfPeople * 15 * 0.05);
                    }
                    else
                    {
                        price = countOfPeople * 15;
                    }
                }
            }
            else if (dayOfWeek == "Saturday")
            {
                if (groupType == "Students")
                {
                    if (countOfPeople >= 30)
                    {
                        price = (countOfPeople * 9.80) - (countOfPeople * 9.80 * 0.15);
                    }
                    else
                    {
                        price = countOfPeople * 9.80;
                    }
                }
                else if (groupType == "Business")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 15.60 - (10 * 15.60);
                    }
                    else
                    {
                        price = countOfPeople * 15.60;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price = (countOfPeople * 20) - (countOfPeople * 20 * 0.05);
                    }
                    else
                    {
                        price = countOfPeople * 20;
                    }
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                if (groupType == "Students")
                {
                    if (countOfPeople >= 30)
                    {
                        price = (countOfPeople * 10.46) - (countOfPeople * 10.46 * 0.15);
                    }
                    else
                    {
                        price = countOfPeople * 10.46;
                    }
                }
                else if (groupType == "Business")
                {
                    if (countOfPeople >= 100)
                    {
                        price = countOfPeople * 16 - (10 * 16);
                    }
                    else
                    {
                        price = countOfPeople * 16;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price = (countOfPeople * 22.50) - (countOfPeople * 22.50 * 0.05);
                    }
                    else
                    {
                        price = countOfPeople * 22.50;
                    }
                }
            }


            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}