namespace Problem_05._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] text = command.Split();

                if (text[0] == "swap")
                {
                    int temp = numbers[int.Parse(text[1])];

                    numbers[int.Parse(text[1])] = numbers[int.Parse(text[2])];
                    numbers[int.Parse(text[2])] = temp;

                }

                if (text[0] == "multiply")
                {
                    numbers[int.Parse(text[1])] *= numbers[int.Parse(text[2])];
                }

                if (text[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = numbers[i] - 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}