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