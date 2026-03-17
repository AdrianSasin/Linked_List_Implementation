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