namespace _03._P_th_Bit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int posicion = int.Parse(Console.ReadLine());

            int mask = 1 << posicion;

            int result = number & mask;

            int lsb = result >> posicion;

            Console.WriteLine(lsb);
        }
    }
}