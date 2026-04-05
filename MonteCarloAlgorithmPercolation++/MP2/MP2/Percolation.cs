public class Percolation
{

    // You are allowed to add reasonable helper method(s) to this class (only this class).

    /// <summary>
    /// Given a grid, it calculates and returns another grid of the same size
    /// where only open cell that can be filled remain true. 
    /// All other cells must be false (i.e. cells that are blocked or open 
    /// cells that are not full).
    /// The original grid must not be mutated.
    /// </summary>
    /// <param name="grid">
    /// an NxN Boolean grid (true means open and false means blocked)
    /// </param>
    /// <returns>another NxN Boolean grid</returns>
    public static bool[,] Infiltrate(bool[,] grid)
    {
        // Get the dimension N of the N x N grid
        int N = grid.GetLength(0);

        // Create a new grid to track which cells are filled (initially all false)
        bool[,] full = new bool[N, N];

        // If grid is empty, return empty grid
        if (N == 0) return full;

        // Start from all open cells in the top row and recursively fill the neighboring spots
        for (int c = 0; c < N; c++)
        {
            if (grid[0,c])
            {
                Fill(grid, full, 0, c);
            }
        }

        // Return resulting reachable cells
        return full;

    }

    /// <summary>
    /// Given a grid, it calculates whether the grid percolates
    /// </summary>
    /// <param name="grid">
    /// an NxN Boolean grid (true means open and false means blocked)
    /// </param>
    /// <returns>true if percolates, false otherwise</returns>
    public static bool IsPercolating(bool[,] grid)
    {
        // Use the Infiltrate method to get the grid showing which cells are filled
        bool[,] full = Infiltrate(grid);

        // Get the dimension N of the N x N grid
        int N = grid.GetLength(0);

        // If any bottom row cell is filled, it means there's a continuous path from top to bottom
        for (int c = 0; c < N; c++)
        {
            if (full[N - 1, c])
            {
                // Found a filled cell in bottom row ( grid percolates )
                return true;
            }
        }
        // No filled cells found in bottom row ( grid does not percolate )
        return false;

    }
    // Helper methods

    private static void Fill(bool[,] grid, bool[,] full, int r, int c)
    {
        int N = grid.GetLength(0);

        // Check bounds
        if (r < 0 || c < 0 || r >= N || c >= N)
        {
            return;
        }

        // If cell is blocked or already filled, return
        if (!grid[r, c] || full[r, c])
        {
            return;
        }


        // Mark current cell as full
        full[r, c] = true;

        // Recursively fill neighbors in all four directions
        Fill(grid, full, r + 1, c); // down
        Fill(grid, full, r - 1, c); // up
        Fill(grid, full, r, c - 1); // left
        Fill(grid, full, r, c + 1); // right

    }
}