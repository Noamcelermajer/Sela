class Board
{
    private int[,] grid;

    public Board(int size)
    {
        Size = size;
        grid = new int[Size, Size];
    }

    public int Size { get; }

    public void PlaceQueen(int row, int col)
    {
        grid[row, col] = 1;
    }

    public void RemoveQueen(int row, int col)
    {
        grid[row, col] = 0;
    }

    public bool IsSafe(int row, int col)
    {
        // Check the row
        for (int i = 0; i < col; i++)
        {
            if (grid[row, i] == 1)
                return false;
        }

        // Check the upper diagonal
        int x = row, y = col;
        while (x >= 0 && y >= 0)
        {
            if (grid[x, y] == 1)
                return false;
            x--;
            y--;
        }

        // Check the lower diagonal
        x = row; y = col;
        while (x < Size && y >= 0)
        {
            if (grid[x, y] == 1)
                return false;
            x++;
            y--;
        }

        return true;
    }

    public void PrintBoard()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
