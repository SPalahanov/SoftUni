namespace _02._Bit_at_Position_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int posicion = 1;
            int mask = 1 << posicion;
            
            int result = number & mask;

            int lsb = result >> 1;

            Console.WriteLine(lsb);

        }
    }
}