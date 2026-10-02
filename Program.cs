using System;

class CircularLinkedList
{
    class Node
    {
        public int Data;
        public Node? Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node? head;

    public void InsertEnd(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node current = head;

        while (current.Next != head)
            current = current.Next!;

        current.Next = newNode;
        newNode.Next = head;
    }

    public void InsertBegin(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node current = head;

        while (current.Next != head)
            current = current.Next!;

        newNode.Next = head;
        current.Next = newNode;
        head = newNode;
    }

    public void InsertSorted(int value)
    {
        if (head == null || value < head.Data)
        {
            InsertBegin(value);
            return;
        }

        Node current = head;

        while (current.Next != head &&
               current.Next!.Data < value)
            current = current.Next!;

        Node newNode = new Node(value);
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public bool Search(int value)
    {
        if (head == null)
            return false;

        Node current = head;

        do
        {
            if (current.Data == value)
                return true;

            current = current.Next!;
        }
        while (current != head);

        return false;
    }

    public bool DeleteNode(int value)
    {
        if (head == null)
            return false;

        Node current = head;
        Node? previous = null;

        do
        {
            if (current.Data == value)
            {
                if (previous == null)
                {
                    if (current.Next == head)
                    {
                        head = null;
                    }
                    else
                    {
                        Node last = head;

                        while (last.Next != head)
                            last = last.Next!;

                        head = current.Next;
                        last.Next = head;
                    }
                }
                else
                {
                    previous.Next = current.Next;

                    if (current == head)
                        head = current.Next;
                }

                return true;
            }

            previous = current;
            current = current.Next!;
        }
        while (current != head);

        return false;
    }

    public void Reverse()
    {
        if (head == null || head.Next == head)
            return;

        Node previous = head;
        Node current = head.Next!;
        Node next;

        while (current != head)
        {
            next = current.Next!;
            current.Next = previous;
            previous = current;
            current = next;
        }

        head.Next = previous;
        head = previous;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Node current = head;

        do
        {
            Console.Write(current.Data + " -> ");
            current = current.Next!;
        }
        while (current != head);

        Console.WriteLine("(back to head)");
    }

    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        list.InsertSorted(20);
        list.InsertSorted(10);
        list.InsertSorted(30);
        list.InsertSorted(25);

        Console.Write("List after sorted insertions: ");
        list.Display();

        Console.WriteLine("Searching for 25: " +
            (list.Search(25) ? "Found" : "Not Found"));

        Console.WriteLine("Searching for 40: " +
            (list.Search(40) ? "Found" : "Not Found"));

        Console.WriteLine("Reversing list...");
        list.Reverse();
        list.Display();

        Console.WriteLine("Deleting 20...");
        list.DeleteNode(20);
        list.Display();
    }
}