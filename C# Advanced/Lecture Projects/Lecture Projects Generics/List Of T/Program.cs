namespace List_Of_T
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = GenericMethod<int>(5);
            List<string> stringList = GenericMethod<string>("Hello");

        }

        /* Не може да се използва T за да се добавят всякакви типове данни на List в горния контекст, защото в този контекст T не съществува

            Ако имаме метод или клас, който има T и е Generic там може да използваме List<T> */

        static List<T> GenericMethod<T>(T value)
        {
            List<T> list = new List<T>();

            list.Add(value);
            list.Add(value);
            list.Add(value);

            Console.WriteLine(value);

            return list;
        }
    }
}