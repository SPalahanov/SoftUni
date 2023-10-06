using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; set; }

        public void AddLast(int nodeValue)
        {
            Count++;
            
            Node newNode = new Node(nodeValue);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;

                return;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode; 
        }

        public void AddFirst(int nodeValue)
        {
            Count++;
            
            Node newNode = new Node(nodeValue);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;

                return;
            }

            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        public Node RemoveLast()
        {
            Node nodeToRemove = Tail;

            Tail = Tail.Previous;
            Tail.Next = null;
            nodeToRemove.Previous = null;

            Count--;

            return nodeToRemove;
        }

        public Node RemoveFirst()
        {
            Node nodeToRemove = Head;

            Head = Head.Next;
            Head.Previous = null;
            nodeToRemove.Next = null;

            Count--;

            return nodeToRemove;
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];

            int index = 0;


            //================//
            ForEach(n =>
            {
                array[index++] = n;
            });


            //Node currentNode = Head;

            //while (currentNode != null)
            //{
            //    array[index++] = currentNode.Value;
            //    currentNode = currentNode.Next;
            //}

            return array;
        }

        public void ForEach(Action<int> callback)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                callback(currentNode.Value);

                currentNode = currentNode.Next;
            }
        }
    }
}
