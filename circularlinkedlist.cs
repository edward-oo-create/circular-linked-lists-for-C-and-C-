using System;

class CircularLinkedList
{
    private class Node
    {
        public int Data;
        public Node? Next;
    \
    ]'[-5r4q
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node? head;

    // Insert at the end
    public void InsertEnd(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node temp = head;

        while (temp.Next != head)
            temp = temp.Next!;

        temp.Next = newNode;
        newNode.Next = head;
    }

    // Insert at the beginning
    public void InsertBegin(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node temp = head;

        while (temp.Next != head)
            temp = temp.Next!;

        newNode.Next = head;
        temp.Next = newNode;
        head = newNode;
    }

    // Insert in ascending order
    public void InsertSorted(int value)
    {
        if (head == null || value <= head.Data)
        {
            InsertBegin(value);
            return;
        }

        Node temp = head;

        while (temp.Next != head &&
               temp.Next!.Data < value)
        {
            temp = temp.Next!;
        }

        Node newNode = new Node(value);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Search for a value
    public bool Search(int value)
    {
        if (head == null)
            return false;

        Node temp = head;

        do
        {
            if (temp.Data == value)
                return true;

            temp = temp.Next!;
        }
        while (temp != head);

        return false;
    }

    // Delete a node by value
    public void DeleteNode(int value)
    {
        if (head == null)
            throw new InvalidOperationException(
                "List is empty. Cannot delete.");

        if (head.Data == value)
        {
            if (head.Next == head)
            {
                head = null;
                return;
            }

            Node tail = head;

            while (tail.Next != head)
                tail = tail.Next!;

            head = head.Next;
            tail.Next = head;
            return;
        }

        Node previous = head;
        Node current = head.Next!;

        while (current != head)
        {
            if (current.Data == value)
            {
                previous.Next = current.Next;
                return;
            }

            previous = current;
            current = current.Next!;
        }

        throw new InvalidOperationException(
            "Value not found in the list.");
    }

    // Reverse the circular linked list
    public void Reverse()
    {
        if (head == null || head.Next == head)
            return;

        Node oldHead = head;
        Node? previous = null;
        Node? current = head;

        do
        {
            Node? nextNode = current!.Next;
            current.Next = previous ?? oldHead;
            previous = current;
            current = nextNode;
        }
        while (current != oldHead);

        head.Next = previous;
        head = previous;
    }

    // Display the list
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Node temp = head;

        do
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next!;
        }
        while (temp != head);

        Console.WriteLine("(back to head)");
    }
}

class Program
{
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        try
        {
            list.InsertSorted(20);
            list.InsertSorted(10);
            list.InsertSorted(30);
            list.InsertSorted(25);

            Console.Write("List after sorted insertions: ");
            list.Display();

            Console.WriteLine(
                "Searching for 25: " +
                (list.Search(25) ? "Found" : "Not Found"));

            Console.WriteLine(
                "Searching for 40: " +
                (list.Search(40) ? "Found" : "Not Found"));

            Console.WriteLine("Reversing list...");
            list.Reverse();
            list.Display();

            Console.WriteLine("Deleting 20...");
            list.DeleteNode(20);
            list.Display();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}