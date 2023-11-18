namespace CreateDynamicObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType(Console.ReadLine());

            object obj = Activator.CreateInstance(type);

            if (obj is Random)
            {
                Console.WriteLine(((Random)obj).Next());
            }

            Console.WriteLine(obj.ToString());
        }
    }
}