using System;
using System.Collections.Generic;

class SortedListDemo
{
    static void Main()
    {
        SortedList<int, string> oddList = new SortedList<int, string>();
        SortedList<int, string> evenList = new SortedList<int, string>();

        for (int i = 1; i <= 9; i += 2)
        {
            oddList.Add(i, "Odd" + i);
        }

        for (int i = 0; i <= 8; i += 2)
        {
            evenList.Add(i, "Even" + i);
        }

        Console.WriteLine("Odd List:");
        PrntSortedList(oddList);

        Console.WriteLine("Even List:");
        PrntSortedList(evenList);

        SortedList<int, string> mergedList = MergedSortLists(oddList, evenList);

        Console.WriteLine("Merged List:");
        PrntSortedList(mergedList);

        Console.WriteLine("Performing deletions in the merged list...");

        DeleteAndPrnt(mergedList, 4);
        DeleteAndPrnt(mergedList, 6);
        DeleteAndPrnt(mergedList, 2);

        Console.WriteLine();
    }

    static void PrntSortedList(SortedList<int, string> list)
    {
        foreach (int key in list.Keys)
        {
            Console.WriteLine("Key: " + key + ", Value: " + list[key]);
        }
        Console.WriteLine();
    }

    static void DeleteAndPrnt(SortedList<int, string> list, int key)
    {
        Console.WriteLine("Deleting node with key: " + key);

        if (list.ContainsKey(key))
        {
            list.Remove(key);
            Console.WriteLine("Node deleted succes!");
            PrntSortedList(list);
        }
    }

    static SortedList<int, string> MergedSortLists(SortedList<int, string> list1, SortedList<int, string> list2)
    {
        SortedList<int, string> mergedList = new SortedList<int, string>();

        foreach (int key in list1.Keys)
        {
            mergedList.Add(key, list1[key]);
        }

        foreach (int key in list2.Keys)
        {
            mergedList.Add(key, list2[key]);
        }

        return mergedList;
    }
}
