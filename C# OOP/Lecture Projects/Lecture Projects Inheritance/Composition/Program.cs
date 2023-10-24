namespace Composition
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class A
    {
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
    }

    class B
    {
        public B()
        {
            A = new A();
        }
        public A A { get; set; }
    }
}

