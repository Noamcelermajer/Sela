
class Shape
{
    int base_triangle = 0;
    int base_square = 0;

    public Shape()
    {
        base_triangle = 4;
        base_square = 4;
    }
    public void set_base_triangle(int base_triangle)
    {
        this.base_triangle = base_triangle;
    }
    
    public void set_base_square(int base_square)
    {   
        this.base_square = base_square;
    }

    // function to print an "*" triangle 
    public void print_triangle()
    {   
        for (int i = 1; i < base_triangle; i++)
        {
            for (int j = 0; j <= base_triangle - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j < i * 2; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

    }

    //function that print a "*" square based on the base_square
    public void print_square()
    {
        Console.WriteLine();
        //first loop print the base_square
        for (int i = 0; i < base_square; i++)
        {
            for (int j = 0; j < base_square; j++)
            {
                Console.Write("*  ");
            }
            Console.WriteLine();
        }
    }

}


