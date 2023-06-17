using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; }
        public Node <T> Next { get; set; }
        public Node <T> Previous { get; set; }
        public int Index { get; set; }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public int Length { get; set; }


        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
            }

            Tail = newNode;
            Tail.Index = Length;
            Length++;
        }


        public void AddAt(int index, T e)
        {
            

        }

        public T ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current= Head;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
