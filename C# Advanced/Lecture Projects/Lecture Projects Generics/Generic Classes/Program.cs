namespace Generic_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            GenericList<string> genericList2 = new GenericList<string>();

            genericList.AddElement(1);
            genericList.AddElement(2);
            genericList.AddElement(3);

            genericList.PrintAllElements();

            
            genericList2.AddElement("Hello");
            genericList2.AddElement("world");
            genericList2.AddElement("!");

            genericList2.PrintAllElements();

        }
    }

    /* Т се декларира от самият клас, класът е generic и в него има типът данни Т, методите използват на класа generic параметъра Т */

    class GenericList<T>
    {
        
        
        private T[] internalArray;

        private int index;

        public GenericList()
        {
            internalArray = new T[10];
        }

        public T[] InternalArray
        {
            get { return internalArray; }
            set { internalArray = value; }
        }

        public T FirstElement
        {
            get { return internalArray[0]; }
        }
        
        public void AddElement(T element)
        {
            internalArray[index++] = element;
        }

        public void PrintAllElements()
        {
            foreach (var item in internalArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}