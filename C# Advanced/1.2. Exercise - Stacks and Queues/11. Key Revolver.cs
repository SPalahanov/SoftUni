namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());

            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int tempGunBarrel = gunBarrelSize;
            int shootingCount = 0;

            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {

                int bullet = bulletsStack.Pop();
                int currentLock = locksQueue.Peek();

                if (bullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                tempGunBarrel--;

                if (tempGunBarrel == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    tempGunBarrel = gunBarrelSize;
                }

                shootingCount++;
            }

            int moneyEarned = valueOfIntelligence - (shootingCount * bulletPrice);

            if (locksQueue.Count > 0 && bulletsStack.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}