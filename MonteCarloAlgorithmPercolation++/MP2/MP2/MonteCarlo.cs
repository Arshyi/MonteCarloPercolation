using System.CodeDom.Compiler;

public class MonteCarloSimulation
{
    /// <summary>
    /// Estimates and returns the percolation probability using the Monte Carlo method
    /// </summary>
    /// <param name="dimension">the grid dimension (each sides of a square two-dimensional grid)</param>
    /// <param name="probability">probability of vacancy</param>
    /// <param name="numOfTrials">number of simulation/trials</param>
    /// <returns>the estimated percolation probability</returns>
    public static double Estimate(int dimension, double probability, int numOfTrials)
    {
        //Validate inputs - dimension must be positive, probability must be between 0 and 1, and number of trials must be positive
        if (dimension <= 0 || probability < 0 || probability > 1 || numOfTrials <= 0)
            return 0.0;

        //Counter to track how many randomly generated grids percolate
        int percolatingCount = 0;

        //Run the simulation for the specified number of trails
        for (int i = 0; i < numOfTrials; i++)
        {
            //Generate a random grid using provided dimension and vacancy
            bool[,] grid = RandomGridGenerator.Generate(dimension, probability);//Generating random grid using Generate method in RandomGridGenerator class

            //Determine if grid percolates by calling IsPercolating method from Percolation class
            if (Percolation.IsPercolating(grid))
                percolatingCount++; //If it percolates, increment count
        }
        //Compute the fraction of trials that resulted in percolation
        //Cast to double to ensure floating-point division instead of integer division.
        double prob = (double)percolatingCount / numOfTrials;
        
        
        return prob;
        
    }
}