namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(' ');

                if (arguments[0] == "Add")
                {
                    list = AddNumber(list, int.Parse(arguments[1]));
                }
                else if (arguments[0] == "Insert")
                {
                    list = InsertNumber(list, int.Parse(arguments[1]), int.Parse(arguments[2]));
                }
                else if (arguments[0] == "Remove")
                {
                    list = RemoveAtIndex(list, int.Parse(arguments[1]));
                }
                else if (arguments[0] == "Shift")
                {
                    if (arguments[1] == "left")
                    {
                        list = ShiftLeft(list, int.Parse(arguments[2]));
                    }
                    else if (arguments[1] == "right")
                    {
                        list = ShiftRight(list, int.Parse(arguments[2]));
                    }
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static List<int> AddNumber(List<int> list, int number)
        {
            list.Add(number);

            return list;
        }

        static List<int> InsertNumber(List<int> list, int number, int index)
        {
            if (IsIndexInsideTheBoundaryOfList(list, index))
            {
                list.Insert(index, number);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }

            return list;
        }

        static List<int> RemoveAtIndex(List<int> list, int index)
        {
            if (IsIndexInsideTheBoundaryOfList(list, index))
            {
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }

            return list;
        }

        static List<int> ShiftLeft(List<int> list, int count)
        {
            count %= list.Count;


            List<int> shifted = list.GetRange(0, count);
            list.RemoveRange(0, count);
            list.InsertRange(list.Count, shifted);

            return list;
        }

        static List<int> ShiftRight(List<int> list, int count)
        {
            count %= list.Count;

            List<int> shifted = list.GetRange(list.Count - count, count);
            list.RemoveRange(list.Count - count, count);
            list.InsertRange(0, shifted);

            return list;
        }

        static bool IsIndexInsideTheBoundaryOfList(List<int> list, int index)
        {
            return index >= 0 && index <= list.Count - 1;
        }
    }
}