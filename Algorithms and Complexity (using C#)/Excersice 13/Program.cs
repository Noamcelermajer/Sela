namespace Excercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            oddNumbers(9876543210);
        }
        public static void oddNumbers(long number)
        {
            if((number % 10 ) % 2 != 0) 
            {
                Console.WriteLine($"{number %10}");
            }
            if( number > 10) {
                oddNumbers(number /10);
            }
            
        }
    }
}