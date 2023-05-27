class Program
{
    static void Main(string[] args)
    {
        string menu = "Welcome to the shape drawing program!\n" + "Please choose one of the following options:\n" + "1. Triangle\n" + "2. Square\n" + "3. Quit\n";
        Shape shape = new Shape();
        
        /*
        * Write a menu that get user input and call the appropriate function based on input
        * if choice is 1 then call shape.print_triangle()
        * if choice is 2 then call shape.print_square()
        * if choice is 3 quit main program
        */
        int choice = 0;

        while(choice != 3)
        {
            Console.WriteLine(menu);
            choice = int.Parse(Console.ReadLine());
            
            //call the appropriate function based on user input via switch
            switch(choice)
            {
                case 1:
                    Console.Clear();
                    shape.print_triangle();
                    break;
                case 2:
                    Console.Clear();
                    shape.print_square();
                    break;
                case 3:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice");
                    break;
            }
            

        }

    }
}