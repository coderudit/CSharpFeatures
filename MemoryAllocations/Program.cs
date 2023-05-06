namespace MemoryAllocations;

public class Program
{
    public static void Main(String[]args)
    {
        //Allocated in the stack.
        int number=420;
        unsafe
        {
            int* pointer = &number;
            Console.Write(*pointer);
        }

        //Will be allocated to heap.
        var app = new Application(25);
        app.SomeMethod(12);
    }
}

class Application
{
    //Will be allocated to heap being part of it's parent class i.e.Application.
    private int _number;

    public Application(int number)
    {
        _number=number;
    }

    //num being the argument and value type, will be allocated on the stack not on the heap.
    public void SomeMethod(int num)
    {
        //These variables are allocated to the stack.
        int a=0;
        int b=5;
        int c=10;

        //These variables get allocated to heap as they are being boxed by the string interpolation because of the boxing.
        //String interpolation uses string.format behind the scenes which accepts object as an argument.
        Console.WriteLine($"{a}{b}{c}");
    }
}