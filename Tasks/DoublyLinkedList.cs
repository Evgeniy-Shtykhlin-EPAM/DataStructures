using System;
using System.Collections;
using System.Collections.Generic;
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
        public int? Index { get; set; }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Length { get; set; }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            if (Tail == null)
            {
                Head = newNode;
                Head.Index = 0;
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
            if (Length == index)
            {
                Node<T> temp = new Node<T>(e);

                temp.Index = index;
                temp.Next = null;
                temp.Previous = Tail;

                Tail.Next = temp;

                Length++;

            }
            else
            {
                Node<T> current = Head;
                while (current.Index != index)
                {
                    current = current.Next;
                }

                Node<T> temp = new Node<T>(e);

                temp.Index = index;
                temp.Next = current.Next;
                temp.Previous = current;

                current.Index = index - 1;
                current.Next = temp;
                Length++;
            }
        }

        public T ElementAt(int index)
        {
            if (Length == 0 || index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> node = Head;
            while (node.Index != index)
            {
                node = node.Next;
            }

            return node.Data;
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
            Node<T> current = Head;

            while (current != Tail)
            {
                current = current.Next;

                if (current.Data.Equals(item))
                {
                    Node<T> prev = current.Previous;
                    prev.Next = null;
                    current.Previous = null;

                    Length--;
                }
            }
        }

        public T RemoveAt(int index)
        {
            if (Length == 0 || index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> currentTemp = Head;

            while (currentTemp.Index != index)
            {
                currentTemp = currentTemp.Next;
            }


            Node<T> prev = currentTemp.Previous;

            if (currentTemp.Next == null)
            {
                prev.Next = null;
            }
            else
            {
                Node<T> next = currentTemp.Next;

                prev.Next = next;
                next.Previous = prev;
                Tail = currentTemp;
            }
            Length--;

            return currentTemp.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
