using System;

namespace Simulation
{
    class SimulationMain
    {
        public static void Main()
        {
            int dimension = 3;  //initial grid dimension
            double vacancyProbability = 0.593; //initial vacancy probability
            int numOfTrials = 100;  //initial num of trials for MC
            bool[,] grid = new bool[3, 3]  //initial default grid;
                                           //also helpful for initial testing considering a specific grid 
            {
                { false, false, false},
                { false, false, false},
                { true, true, false}
            };

            while (true) //while loop to keep showing the menu even after user inputs
            {
                Console.WriteLine("Select from this menu:");
                Console.WriteLine("Grid parameters: di(m)ension, (v)acancy probability, (n)um of trials, (g)et parameters");
                Console.WriteLine("Single grid: (c)reate a grid, (d)isplay, (p)ercolate");
                Console.WriteLine("Monte Carlo: start Mon(t)e Carlo simulation");
                Console.WriteLine("Quit: (q)uit");
                Console.Write("\nYour choice: "); //adds the space between the menu and your choice
                string choice; //instantiate the variable choice, that we will later use to record the user inputs.
                string result = "";
                try
                {
                    choice = Console.ReadLine().Trim().ToLower(); //reads the input of the user and saves it as "choice", we use ToLower to account for varying user inputs
                }
                catch (Exception) //catches exceptions
                {
                    Console.WriteLine($"IO error");
                    continue;
                }
                if (choice.StartsWith("m")) //if the user presses "m" on their keyboard to the menu
                {
                    // implement your code below here
                    Console.Write("Dimension of the grid (3 to 50)? "); //prompt for user
                    string err = "";
                    int newDim; // the new dimension

                    if (!GetInt(out newDim, 3, 50, ref err))
                    {
                        Console.WriteLine(err); //error
                    }
                    else //if there is no error
                    {
                        dimension = newDim; //make the new user inputted dimension the actual dimension
                        grid = new bool[dimension, dimension]; //make new grid with new dimensions
                    }
                }
                if (choice.StartsWith("g")) //if the user types in the letter g
                {
                    //inside if statement
                    Console.WriteLine($"current dimension = {dimension}, vacancy probability = {vacancyProbability}, num of trials = {numOfTrials}");
                    //the line above will outout the dimension, probability and number of trials to the console for the user to see
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (choice.StartsWith("q")) //if the user types q to quit the program
                {
                    //inside the if statement
                    return; //better than break, because it exits the while loop entirely
                }
                if (choice.StartsWith("v")) //if the user enters "v" 
                {
                    //inside if statement
                    Console.Write("Probability of vacancy (0 to 1)? "); //prompt for user
                    string err = "";
                    double newProbability; //create the double new probability which the user inputs

                    if (!GetDouble(out newProbability, 0.0, 1.0, ref err)) //check for errors, call method to do so
                    {
                        Console.WriteLine(err);   //not an acceptable number
                    }
                    else //if the number entered is valid
                    {
                        vacancyProbability = newProbability;   //set the probability the user entered to the actual one
                    }
                }  

                if (choice.StartsWith("d")) //if the user enters d
                {
                    Visualization.VisualizeGrid(grid); //call the visualize grid visualizer in order to output the grid to the user
                }
                if (choice.StartsWith("p")) //if the suer enters the letter p
                {
                    Visualization.VisualizeGrid(grid); //this will show the original grid we had before
                    bool[,] full = Percolation.Infiltrate(grid); //this will infiltrate the grid
                    Visualization.VisualizeProcessedGrid(grid, full); //this will show the processed grids, aka the green highlight
                    // 4. Print percolation result
                    bool percolates = Percolation.IsPercolating(grid); //check for percolation
                    Console.WriteLine("Percolates: " + percolates); //print the result of the percolation
                }
                if (choice.StartsWith("c")) //if the user enters c
                {
                    grid = RandomGridGenerator.Generate(dimension, vacancyProbability); //this will make the new grid
                    Visualization.VisualizeGrid(grid); //this will display the grid
                }
                if (choice.StartsWith("t")) //if the user enters t
                {
                    double probability = MonteCarloSimulation.Estimate(dimension, vacancyProbability, numOfTrials); //runs the simulation
                    //probability is the decimal probability, which means we need to times it by number of trials to get number of successful trials:
                    double successfulTrials = probability * numOfTrials; //introduce our number of successful trials
                    Console.WriteLine($"{Convert.ToInt32(successfulTrials)} percolates out of {numOfTrials}"); //prints how many percolate out of how many trials (optional portion)
                    Console.WriteLine($"Percolation probability is {probability}"); //prints the percolation probability
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (choice.StartsWith("n")) //if the user enters n
                {
                    Console.Write("Number of trials (10 to 50000)? "); //prompts the user to type a number of trials

                    string err = "";
                    int newN; //define the variable that is going to be the new n value

                    if (!GetInt(out newN, 10, 50000, ref err)) //check for invalid inputs
                    {
                        Console.WriteLine(err); //error
                    }
                    else //if there is no error found
                    {
                        numOfTrials = newN; // set the number of trials equal to the input of the user
                    }
                }
            }
        }

        static bool GetInt(out int num, int min, int max, ref string str)
        {
            if (int.TryParse(Console.ReadLine().Trim(), out num))
            {
                if (num >= min && num <= max)
                {
                    return true;
                }
                str = "Number outside range";
            }
            else
            {
                str = "Not an acceptable number";
            }
            return false;
        }

        static bool GetDouble(out double num, double min, double max, ref string str)
        {
            if (double.TryParse(Console.ReadLine().Trim(), out num))
            {
                if (num >= min && num <= max)
                {
                    return true;
                }
                str = "Number outside range";
            }
            else
            {
                str = "Not an acceptable number";
            }
            return false;
        }
    }
}
