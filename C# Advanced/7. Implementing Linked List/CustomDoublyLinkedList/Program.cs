using System.Threading.Channels;

namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList linkedList = new SoftUniLinkedList();
            
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.AddFirst(5);
            linkedList.AddFirst(5);


            linkedList.RemoveFirst();

            linkedList.RemoveLast();
            
            
            int listSum = 0;

            linkedList.ForEach(x =>
            {
                listSum += x;
                Console.WriteLine($"From Foreach: {x}");
            });

            Console.WriteLine(listSum);
        }
    }
} 