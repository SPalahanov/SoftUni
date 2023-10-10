namespace Object_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObjectList objectList = new ObjectList();

            objectList.Add(1);
            objectList.Add("string");


            // кастваме променливата към число //
            int firstElement = (int)objectList.internalArray[0];
        }
    }

    class ObjectList
    {
        public object[] internalArray;
        private int index = 0;

        public ObjectList()
        {
            internalArray = new object [10];
        }

        public void Add(object element)
        {
            internalArray[index++] = element;
        }
    }
}