namespace SealedClasses
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    //Ако един клас е sealed, то той не може да бъде наследяван от друг клас//
    /*sealed*/ class SealedClass
    {
        public int MyProperty { get; set; }
    }

    class B : SealedClass
    {

    }
}


