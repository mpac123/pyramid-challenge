using System;

namespace pyramid_challenge
{
    public class PyramidSolver
    {
        public static (int, int[]) FindMaxPath(int [,] pyramid)
        {
            var filtered_pyramid = FilterPyramid(pyramid);
            var N = pyramid.GetLength(0);

            // array in which all calculated sums are stored, 
            // row by row, starting from the bottom
            var sums_pyramid = new int[N, N];

            // The most bottom row stays the same
            for (var i = 0; i < N; i++)
            {
                sums_pyramid[N-1, i] = pyramid[N-1, i];
            }

            // For the rest of rows, I fill in each field in the array with the largest of the sums
            // of the path from the field to the bottom of the pyramid
            for (var i = N-2; i >= 0; i--)
            {
                for (var j = 0; j <= i; j++)
                {
                    // if path cannot go through a field, I put -1 in the sum_pyramid array in the corresponding field
                    if ((pyramid[i+1, j] == -1 && pyramid[i+1, j+1] == -1) || pyramid[i, j] == -1)
                    {
                        sums_pyramid[i,j] = -1;
                    } else {
                        sums_pyramid[i,j] = pyramid[i,j] + Math.Max(sums_pyramid[i+1, j], sums_pyramid[i+1, j+1]);
                    }
                }
            }

            // Now, I traverse the sum_pyramid from top to bottom, always choosing maximum element.
            // I collect the values from the original pyramid in these indices, as this is the maximum path
            // that I am looking for
            var path = new int[N];
            path[0] = pyramid[0,0];
            var index = 0;
            for (var i = 1; i < N; i++)
            {
                if (sums_pyramid[i,index] < sums_pyramid[i,index+1]) {
                    index = index + 1;
                } 
                path[i] = pyramid[i,index];
            }
            return (sums_pyramid[0,0], path);
        }

        // Replace with -1 all the elements that cannot be on the path
        private static int[,] FilterPyramid(int[,] pyramid)
        {
            var top_element = pyramid[0,0];
            var N = pyramid.GetLength(0);

            for (var i = 1; i < N; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    // go through each row; 
                    // replace with -1 all the odd numbers in rows that were 
                    // supposed to have only even numbers and vice versa
                    if ((pyramid[i,j] % 2 == top_element % 2) == (i % 2 == 1)) {
                        pyramid[i,j] = -1;
                    }
                }
            }

            return pyramid;
        }
    }
}