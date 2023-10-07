namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList(); 

            list.Add(5);
            list.Add(4);
            list.Add(8);
            list.Add(1);
            list.Add(3);

            list[0] = -7;
            
            Console.WriteLine(list[2]);

            list.AddRange(new int[] {1, 2, 3, 4});

            Console.WriteLine(list.RemoveAt(1));
            Console.WriteLine(list.RemoveAt(1));
            Console.WriteLine(list.RemoveAt(1));

            list.InsertAt(0, -6);

            Console.WriteLine(list.Contains(8));
            Console.WriteLine(list.Contains(3));

            list.Swap(0, 1);

            Console.WriteLine();
        }
    }
}