using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public T Dequeue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException();

            }
            Node<T> node = Head;

            Node<T> nextNode = Head.Next;

            nextNode.Previous = null;

            Head = nextNode;

            return node.Data;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

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
        }

        public T Pop()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException();
            }
            return Tail.Data;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);

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
        }
    }
}
