namespace InterfaceInheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    interface Readable
    {
        string Read();
    }

    interface Writable : Readable
    {
        void Write(string text0);
    }

    class Printer : Writable
    {
        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string text0)
        {
            throw new NotImplementedException();
        }
    }
}