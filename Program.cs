using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        var test = new Node<int>(1, new Node<int>(2, new Node<int>(3)));
        PrintSingleLinkedList(test);
    }

    static void PrintSingleLinkedList<T>(Node<T> head)
    {
        Console.Write("head -> ");
        var current = head;
        while (current != null)
        {
            Console.Write(current);
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    static void AddAtEndOfSingleLinkedList<T>(T element, ref Node<T>? head)
    {
        if (head == null)
        {
            head = new Node<T>(element);
            return;
        }

        var current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new Node<T>(element);
    }
    static Node<T> CreateSingleLinkedList<T>(params T[] arr)
    {
        if (arr == null ||  arr.Length == 0)
        {
            return null;
        }
        var head = new Node<T>(arr[0]);
        var current = head;
        for (int i = 1; i < arr.Length; i++)
        {
            current.Next = new Node<T>(arr[i]);
            current = current.Next;
        }
        return head;
    }

    static Node<T> ReverseSingleLinkedList<T>(Node<T> head)
    {
        Node<T> prev = null, next;
        while (head != null)
        {
            next = head.Next;
            head.Next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }
    static void MoveLastNodeToFront<T>(ref Node<T> head)
    {
        if (head == null || head.Next == null)
        {
            return;
        }
        var secondLast = head;
        while (secondLast.Next.Next != null)
        {
            secondLast = secondLast.Next;
        }
        var lastNode = secondLast.Next;
        secondLast.Next = null;
        lastNode.Next = head;
        head = lastNode;
    }

    static void RemoveNodeAt<T>(int position, ref Node<T> head)
    {
        if (position < 0 || head == null)
        {
            return;
        }
        if (position == 0)
        {
            head = head.Next;
            return;
        }
        var current = head;
        for (int i = 0; current != null && i < position - 1; i++)
        {
            current = current.Next;
        }
        if (current == null || current.Next == null)
        {
            return;
        }
        current.Next = current.Next.Next;
    }

    static void RemoveAllDuplicatesFromSortedLinkedList<T>(ref Node<T> head)
    where T : IEquatable<T>, IComparable<T>
    {
        Node<T> dummy = new Node<T>(default(T), head), prev = dummy, curr = head;
        while (curr != null)
        {
            bool dup = false;
            while (curr.Next != null && curr.Data.Equals(curr.Next.Data))
            {
                dup = true;
                curr = curr.Next;
            }
            if (dup) prev.Next = curr.Next;
            else prev = curr;
            curr = curr.Next;
        }
        head = dummy.Next;
    }
    static void DistinctElementsInLinkedList<T>(ref Node<T> head)
    where T : IEquatable<T>, IComparable<T>
    {
        for (Node<T> current = head; current != null; current = current.Next)
        {
            Node<T> prev = current;
            for (Node<T> runner = current.Next; runner != null;)
            {
                if (current.Data.Equals(runner.Data))
                {
                    prev.Next = runner.Next;
                    runner = runner.Next;
                }
                else
                {
                    prev = runner;
                    runner = runner.Next;
                }
            }
        }
    }

}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data, Node<T>? next = null)
    {
        Data = data;
        Next = next;
    }

    public override string ToString()
    {
        return $"{Data} -> ";
    }
}