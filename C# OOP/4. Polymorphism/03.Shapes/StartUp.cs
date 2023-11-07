namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Rectangle(5, 10);
            Console.WriteLine(shape.Draw());

            Shape shape2 = new Circle(4);
            Console.WriteLine(shape2.Draw());
        }
    }
}