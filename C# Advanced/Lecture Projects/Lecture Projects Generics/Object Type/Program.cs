using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Object_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // една променлива от тип , може да възприеме всеки един тип данни и всяка една стойност //

            object everyting = new object();

            everyting = 5;

            // от променлива тип обект, за да запазим в друга променлива трябва на кастнем //
            int number = (int)everyting;

            everyting = "hello";

            everyting = new List<int>();

            Print(5);
            Print("Hello");


        }

        static void Print<T>(T anything)
        {
            Console.WriteLine(anything);
        }
    }
}