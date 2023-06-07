namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine()
                .Split()
                .ToArray();

            string[] array2 = Console.ReadLine()
                .Split()
                .ToArray();
            
            string text = " ";

            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < array1.Length; j++)
                {
                    if (array2[i] == array1[j])
                    {
                        Console.Write($"{array2[i]} ");
                    }
                }
            }
            
        }
    }
}