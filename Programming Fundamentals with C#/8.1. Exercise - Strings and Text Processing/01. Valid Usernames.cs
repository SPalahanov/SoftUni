namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > 3 && input[i].Length < 16)
                {
                    if (input[i].Contains('-') || input[i].Contains('_'))
                    {
                        Console.WriteLine(input[i]);
                    }

                    int temp = 1;

                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (!char.IsLetterOrDigit(input[i][j]))
                        {
                            temp = 0;
                        }
                    }

                    if (temp != 0)
                    {
                        Console.WriteLine(input[i]);
                    }
                }
            }
        }
    }
}