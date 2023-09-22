namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenlightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command = String.Empty;

            int passedCars = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    continue;
                }

                int currentGreenLightDuration = greenlightDuration;
                while (cars.Count > 0 && currentGreenLightDuration > 0) 
                {
                    string currentCar = cars.Dequeue();

                    if (currentGreenLightDuration - currentCar.Length > 0)
                    {
                        currentGreenLightDuration -= currentCar.Length;
                        passedCars++;
                        
                    }
                    else  if (currentGreenLightDuration + freeWindowDuration - currentCar.Length >= 0)
                    {
                        passedCars++;
                        break;
                    }
                    else
                    {
                        char hittedSymbol = currentCar[currentGreenLightDuration + freeWindowDuration];
                        
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedSymbol}.");

                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}