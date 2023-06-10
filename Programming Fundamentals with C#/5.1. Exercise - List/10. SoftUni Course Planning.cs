using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] arguments = command.Split(":");

                if (arguments[0] == "Add")
                {
                    list = AddTitle(list, arguments[1]);
                }
                else if (arguments[0] == "Insert")
                {
                    list = InsertTitle(list, arguments[1], int.Parse(arguments[2]));
                }
                else if (arguments[0] == "Remove")
                {
                    list = RemoveTitle(list, arguments[1]);
                }
                else if (arguments[0] == "Swap")
                {
                    list = SwapTitle(list, arguments[1], arguments[2]);
                }
                else if (arguments[0] == "Exercise")
                {
                    list = InsertExercise(list, arguments[1]);
                }
            }

            PrintEachLessonOnNewLineWithItsIndex(list);
        }

        static List<string> AddTitle(List<string> list, string title)
        {
            if (!list.Contains(title))
            {
                list.Add(title);
            }

            return list;
        }

        static List<string> InsertTitle(List<string> list, string title, int index)
        {
            if (!list.Contains(title))
            {
                list.Insert(index, title);
            }

            return list;
        }

        static List<string> RemoveTitle(List<string> list, string title)
        {
            list.Remove(title);

            string exerciseTitle = $"{title}-Exercise";
            int index = list.IndexOf(exerciseTitle);

            if (index >= 0)
            {
                RemoveTitle(list, exerciseTitle);
            }

            return list;
        }

        static List<string> SwapTitle(List<string> list, string firstTitle, string secondTitle)
        {
            if (list.Contains(firstTitle) && list.Contains(secondTitle))
            {
                int firstTitleIndex = list.IndexOf(firstTitle);
                int secondTitleIndex = list.IndexOf(secondTitle);

                string temp = list[firstTitleIndex];
                list[firstTitleIndex] = list[secondTitleIndex];
                list[secondTitleIndex] = temp;

                list = SwapExercise(list, firstTitle, secondTitleIndex);
                list = SwapExercise(list, secondTitle, firstTitleIndex);
            }

            return list;
        }

        static List<string> SwapExercise(List<string> list, string title, int titleIndex)
        {
            string exerciseTitle = $"{title}-Exercise";
            int index = list.IndexOf(exerciseTitle);

            if (index >= 0)
            {
                RemoveTitle(list, exerciseTitle);
                InsertTitle(list, exerciseTitle, titleIndex + 1);
            }

            return list;
        }

        static List<string> InsertExercise(List<string> list, string title)
        {
            string listTitle = $"{title}-Exercise";
            
            if (!list.Contains(title))
            {
                AddTitle(list, title);
            }


            if (list.Contains(title) && !list.Contains(listTitle))
            {
                int titleIndex = list.IndexOf(title);
                InsertTitle(list, listTitle, titleIndex + 1);
            }
            return list;
        }

        static void PrintEachLessonOnNewLineWithItsIndex(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }
    }
}