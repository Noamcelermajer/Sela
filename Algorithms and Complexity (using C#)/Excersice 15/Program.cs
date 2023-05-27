class Program
{
    static int N = 8;

    static bool SolveNQueens(Board board, int col)
    {
        // Base case: all queens are placed
        if (col >= N)
            return true;

        for (int row = 0; row < N; row++)
        {
            if (board.IsSafe(row, col))
            {
                // Place the queen at (row, col)
                board.PlaceQueen(row, col);

                // Recursively place queens in the remaining columns
                if (SolveNQueens(board, col + 1))
                    return true;

                // If placing the queen at (row, col) doesn't lead to a solution,
                // backtrack and remove the queen from the cell.
                board.RemoveQueen(row, col);
            }
        }

        return false;
    }

    static void Main()
    {
        Board board = new Board(N);

        if (SolveNQueens(board, 0))
        {
            board.PrintBoard();
        }
        else
        {
            Console.WriteLine("No solution exists.");
        }
    }
}
