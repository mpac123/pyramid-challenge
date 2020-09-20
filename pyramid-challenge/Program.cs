using System;
using System.IO;

namespace pyramid_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            if (args.Length < 1) {
                Console.WriteLine("Please provide path to the file with input data.");
                return;
            }
            // Read data from the path provided as a command line argument
            int[,] array = null;
            try
            {
                array = FileReader.Read(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error when reading data from file: {e.Message}");
                return;
            }

            // Solve the challenge
            var (max, path) = PyramidSolver.FindMaxPath(array);

            // Output the data
            Console.WriteLine($"Max sum: {max}");

            Console.Write("Path: ");
            for (var i = 0; i < path.Length; i++)
            {
                Console.Write(path[i] + "; ");
            }
        }
    }
}
