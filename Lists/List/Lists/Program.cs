using System;

public class Program
{
    public static void Main()
    {
        ArrayList<int> myList = new ArrayList<int>();
        myList.Add(10);
        myList[0] = myList[0] + 1;
        int removedElement = myList.RemoveAt(0);

        Console.WriteLine(removedElement);
    }
}
