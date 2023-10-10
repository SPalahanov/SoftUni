namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();

            Human human2 = new Student();
        }
    }

    class Human
    {
        public string Name { get; set; }
    }

    class Student : Human
    {
        
    }
}