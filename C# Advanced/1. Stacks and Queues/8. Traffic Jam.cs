namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = String.Empty;

            Queue<string> cars = new Queue<string>();

            int passedCarsCount = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    string passedCar = String.Empty;

                    if (cars.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            passedCar = cars.Dequeue();

                            passedCarsCount++;

                            Console.WriteLine($"{passedCar} passed!");
                        }
                    }

                    if (cars.Count < n)
                    {
                        for (int i = 0; i < cars.Count; i++)
                        {
                            passedCar = cars.Dequeue();

                            passedCarsCount++;

                            Console.WriteLine($"{passedCar} passed!");
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}