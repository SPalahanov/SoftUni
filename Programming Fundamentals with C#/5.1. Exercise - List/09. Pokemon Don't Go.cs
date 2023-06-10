namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            
            while (list.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                int removedElement = 0;

                if (index > list.Count - 1)
                {
                    removedElement = list.ElementAt(list.Count - 1);
                    list.RemoveAt(list.Count - 1);
                    int firstelement = list.ElementAt(0);
                    list.Add(firstelement);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removedElement)
                        {
                            list[i] += removedElement;
                        }
                        else if (list[i] > 0)
                        {
                            list[i] -= removedElement;
                        }
                    }

                }
                else if (index < 0)
                {
                    removedElement = list.ElementAt(0);
                    list.RemoveAt(0);
                    int lastElement = list.ElementAt(list.Count - 1);
                    list.Add(lastElement);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removedElement)
                        {
                            list[i] += removedElement;
                        }
                        else if (list[i] > 0)
                        {
                            list[i] -= removedElement;
                        }
                    }
                }
                else if (index >= 0 && index <= list.Count - 1)
                {
                    removedElement = list.ElementAt(index);

                    list.RemoveAt(index);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removedElement)
                        {
                            list[i] += removedElement;
                        }
                        else if (list[i] > 0)
                        {
                            list[i] -= removedElement;
                        }
                    }
                }

                sum += removedElement;
            }
            Console.WriteLine(sum);
        }
    }
}