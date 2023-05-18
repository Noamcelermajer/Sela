
using System;
class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine(multiples(9876));
    }

    public static int multiples(int number)
    {
        if(number < 10)
        {
            return number;
        }
        return number % 10 * multiples(number / 10);
    }
}
