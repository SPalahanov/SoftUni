using System.ComponentModel;
using Moq;
using Range = Moq.Range;

namespace MoqFunctionalities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mock<IICalculator> mockCalculator = new Mock<IICalculator>();

            

            mockCalculator.Setup(c => c.Add(It.IsInRange(0, 100, Range.Exclusive), It.IsAny<int>())).Returns(55);
            mockCalculator.Setup(c => c.Add(It.IsInRange(101, 1000, Range.Exclusive), It.IsAny<int>())).Returns(555);

            mockCalculator.Setup(c => c.Add(5, 6)).Returns(300);

            mockCalculator.Setup(c => c.Minus(It.IsAny<int>(), It.IsAny<int>())).Returns((int a, int b) =>
            {
                global::System.Console.WriteLine("In Minus method with params {a} {b}");
                return a - b;
            });


            IICalculator calculator = mockCalculator.Object;

            Console.WriteLine($"Add(5, 6) -> {calculator.Add(5, 6)}");
            Console.WriteLine($"Add(50, 60) -> {calculator.Add(50, 60)}");
            Console.WriteLine($"Add(500, 6) -> {calculator.Add(500, 6)}");
            Console.WriteLine($"Minus(5, 6) -> {calculator.Minus(5, 6)}");
        }
    }

    public interface IICalculator
    {
        int Add(int a, int b);
        int Minus(int a, int b);
    }

    public class MockCalculator : IICalculator
    {
        public int Add(int a, int b)
        {
            if (a == 5 && b == 6)
            {
                return 300;
            }

            if (a > 0 && a <= 100)
            {
                return 55;
            }
            else if (a >= 101 && a < 1000)
            {
                return 555;
            }

            return 55;
        }

        public int Minus(int a, int b)
        {
            return 0;
        }
    }
}