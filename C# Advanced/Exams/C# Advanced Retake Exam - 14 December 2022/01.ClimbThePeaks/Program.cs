namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodQuantities = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> staminaQuantities = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int peekCounter = 0;

            List<string> conqueredPeaks = new();


            while (foodQuantities.Any() && staminaQuantities.Any())
            {
                int sum = foodQuantities.Pop() + staminaQuantities.Dequeue();

                if (peekCounter == 0)
                {
                    while (sum < 80 && foodQuantities.Any() && staminaQuantities.Any())
                    {
                        sum = foodQuantities.Pop() + staminaQuantities.Dequeue();
                    }

                    if (sum >= 80)
                    {
                        conqueredPeaks.Add("Vihren");

                        peekCounter++;
                    }
                    
                }
                else if (peekCounter == 1)
                {
                    while (sum < 90)
                    {
                        sum = foodQuantities.Pop() + staminaQuantities.Dequeue();
                    }

                    if (sum >= 90)
                    {
                        conqueredPeaks.Add("Kutelo");

                        peekCounter++;
                    }
                    
                }
                else if (peekCounter == 2)
                {
                    while (sum < 100)
                    {
                        sum = foodQuantities.Pop() + staminaQuantities.Dequeue();
                    }

                    if (sum >= 100)
                    {
                        conqueredPeaks.Add("Banski Suhodol");

                        peekCounter++;
                    }
                    
                }
                else if (peekCounter == 3)
                {
                    while (sum < 60)
                    {
                        sum = foodQuantities.Pop() + staminaQuantities.Dequeue();
                    }

                    if (sum >= 60)
                    {
                        conqueredPeaks.Add("Polezhan");

                        peekCounter++;
                    }
                    
                }
                else if (peekCounter == 4)
                {
                    while (sum < 70)
                    {
                        sum = foodQuantities.Pop() + staminaQuantities.Dequeue();
                    }

                    if (sum >= 70)
                    {
                        conqueredPeaks.Add("Kamenitza");

                        peekCounter++;
                    }
                }
            }

            if (peekCounter == 5)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Any())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var conqueredPeak in conqueredPeaks)
                {
                    Console.WriteLine(conqueredPeak);
                }
            }
        }
    }
}