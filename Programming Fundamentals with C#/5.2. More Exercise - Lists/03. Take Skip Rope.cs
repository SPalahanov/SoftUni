namespace _03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char[] arr = text.ToCharArray();

            string result = string.Empty;

            List<string> list = new List<string>();

            List<int> numbers = new List<int>();

            List<string>nonNumbers = new List<string>();

            List<int> takeList = new List<int>();

            List<int> skipList = new List<int>();
           
            foreach (char c in arr)
            {
                list.Add(c.ToString());
            }

            foreach (char c in arr)
            {
                if (Char.IsDigit(c))
                {
                    numbers.Add(Int32.Parse(c.ToString()));
                }
                else
                {
                    nonNumbers.Add(c.ToString());
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0 || i == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            
            int index = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                int take = takeList[i];
                int skipe = skipList[i];

                if (index + take > nonNumbers.Count)
                {
                    take = nonNumbers.Count - index;
                }

                for (int j = 0; j < take; j++)
                {
                    result += nonNumbers[index + j];
                }

                index += take + skipe;
            }

            Console.WriteLine(result);
        }
    }
}