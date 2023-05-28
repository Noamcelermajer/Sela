using System;

class SortedListExample
{
    class Node
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Node Next { get; set; }
        public static int Count =  0 ;

        public Node(int key, string value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
        public Node()
        {
            Key += Count;
            Next = null;
            Count++;
        }
    }

    static void Main()
    {
        Node list1 = null;
        for (int i = 9; i >= 1; i -= 2)
        {
            list1 = Insert(list1, i, $"Value {i}");
        }

        Node list2 = null;
        for (int i = 8; i >= 0; i -= 2)
        {
            list2 = Insert(list2, i, $"Value {i}");
        }

        Node mergedList = Merge(list1, list2);

        PrintList(mergedList);

        mergedList = Delete(mergedList, 2);
        mergedList = Delete(mergedList, 7);
        try
        {
            mergedList = Delete(mergedList, 10);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        PrintList(mergedList);
    }

    static Node Insert(Node head, int key, string value)
    {
        Node newNode = new Node(key, value);

        if (head == null || key < head.Key)
        {
            newNode.Next = head;
            return newNode;
        }

        Node current = head;
        while (current.Next != null && key >= current.Next.Key)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;

        return head;
    }

    static Node Delete(Node head, int key)
    {
        if (head == null)
        {
            throw new Exception("List is empty. Cannot delete from an empty list.");
        }

        if (head.Key == key)
        {
            return head.Next;
        }

        Node current = head;
        while (current.Next != null && current.Next.Key != key)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            throw new Exception($"Record with key {key} not found in the list.");
        }

        current.Next = current.Next.Next;
        return head;
    }

    static Node Merge(Node list1, Node list2)
    {
        Node mergedList = null;
        Node tail = null;

        while (list1 != null && list2 != null)
        {
            if (list1.Key < list2.Key)
            {
                if (mergedList == null)
                {
                    mergedList = list1;
                    tail = list1;
                }
                else
                {
                    tail.Next = list1;
                    tail = tail.Next;
                }

                list1 = list1.Next;
            }
            else
            {
                if (mergedList == null)
                {
                    mergedList = list2;
                    tail = list2;
                }
                else
                {
                    tail.Next = list2;
                    tail = tail.Next;
                }

                list2 = list2.Next;
            }
        }

        if (list1 != null)
        {
            tail.Next = list1;
        }

        if (list2 != null)
        {
            tail.Next = list2;
        }

        return mergedList;
    }

    static void PrintList(Node head)
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"Key: {current.Key}, Value: {current.Value}");
            current = current.Next;
        }

        Console.WriteLine();
    }
}
