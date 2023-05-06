// See https://aka.ms/new-console-template for more information

using System.Collections;

public class BoxingUnboxingWorld
{
    public static void Main(string[] args)
    {
        //1. boxing/unboxing
        //Number gets allocated on stack.
        int number = 420;
        //Boxing is implicit and happens when int assigned to object and gets allocated to heap.
        //20 times slower than a normal assignment.
        object boxedObject = number;
        //Unboxing is explicit and happens when object is assigned to int
        //4 times slower than a normal assignment.
        int unboxedNumber = (int)boxedObject;

        var arrayOfInts = Enumerable.Range(1, 100).ToArray();
        //Boxing happens, as array list consists box the values to object[].
        var arrayList = new ArrayList(arrayOfInts);
        //No boxing happens
        var list = new List<int>(arrayOfInts);
    }
}