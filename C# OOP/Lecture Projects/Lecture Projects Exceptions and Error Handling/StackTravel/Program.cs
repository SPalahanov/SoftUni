using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace StackTravel
{
    public class Program
    {
        static void Main(string[] args)
        {
            FirstMethod();
            
            
            void FirstMethod()
            {
                Console.WriteLine("Before FirstMethod");

                SecondMethod();

                Console.WriteLine("After FirstMethod");
            }
            void SecondMethod()
            {
                Console.WriteLine("Before SecondMethod");

                try
                {
                    ThirdMethod();
                }
                catch 
                {
                    Console.WriteLine("Caught in third method");
                }

                Console.WriteLine("After SecondMethod");
            }

            void ThirdMethod()
            {
                Console.WriteLine("Before ThirdMethod");

                FourthMethod();

                Console.WriteLine("After ThirdMethod");
            }

            void FourthMethod()
            {
                Console.WriteLine("Before FourthMethod");

                throw new NotImplementedException();

                Console.WriteLine("After FourthMethod");
            }
        }

        
    }
}