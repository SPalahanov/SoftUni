using System.Net.WebSockets;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSomething<int>(5);

            PrintSomething<string>("Hello");

            PrintSomething<List<int>>(new List<int>() {6});
        }

        /* Работи с всеки тип данни */

        static void PrintSomething<T>(T input)
        {
            /* Печатеме типа/името на данните */
            Console.WriteLine(typeof(T).Name);
            
            Console.WriteLine($"Generic print something: {input}");
        }

        /* Идеята на дженериците е един метод да може да работи с монго параметри и много типове */
    }
}