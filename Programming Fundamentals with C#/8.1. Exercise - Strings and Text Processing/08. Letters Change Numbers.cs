using System.Text;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            int num;

            decimal sum2 = 0;

            decimal totalSum = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (j > 0 && j < input[i].Length - 1)
                    {
                        sb.Append(input[i][j]);
                    }

                    if (j == input[i].Length - 1 && char.IsLower(input[i][0]))
                    {
                        num = Convert.ToInt32(sb.ToString());

                        if (j == input[i].Length - 1 && char.IsLower(input[i][input[i].Length - 1]))
                        {
                            sum2 = num * Convert.ToDecimal(Convert.ToInt32(input[i][0]) - 96) + (Convert.ToInt32(input[i][input[i].Length - 1]) - 96);
                        }
                        else if (j == input[i].Length - 1 && !char.IsLower(input[i][input[i].Length - 1]))
                        {
                            sum2 = num * Convert.ToDecimal(Convert.ToInt32(input[i][0]) - 96) - (Convert.ToInt32(input[i][input[i].Length - 1]) - 64);
                        }
                    }
                    else if (j == input[i].Length - 1 && !char.IsLower(input[i][0]))
                    {
                        num = Convert.ToInt32(sb.ToString());

                        if (j == input[i].Length - 1 && char.IsLower(input[i][input[i].Length - 1]))
                        {
                            sum2 = num / Convert.ToDecimal(Convert.ToInt32(input[i][0]) - 64) + (Convert.ToInt32(input[i][input[i].Length - 1]) - 96);
                        }
                        else if (j == input[i].Length - 1 && !char.IsLower(input[i][input[i].Length - 1]))
                        {
                            sum2 = num / Convert.ToDecimal(Convert.ToInt32(input[i][0]) - 64) - (Convert.ToInt32(input[i][input[i].Length - 1]) - 64);
                        }
                    }
                }

                totalSum += sum2;

                if (input[i] == "")
                {
                    totalSum -= sum2;
                }
            }

            Console.WriteLine($"{Math.Round(totalSum,2, MidpointRounding.ToZero)}");


        }
    }
}