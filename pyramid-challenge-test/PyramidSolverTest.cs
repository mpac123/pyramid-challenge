using System;
using System.Collections.Generic;
using System.Linq;
using pyramid_challenge;
using Xunit;

namespace pyramid_challenge_test
{
    public class PyramidSolverTest
    {

        public static IEnumerable<object[]> GetTestCases()
        {
            int[,] array1 = new int[,]{ {1, 0, 0, 0, 0},
                                    {8, 3, 0, 0, 0},
                                    {2, 3, 4, 0, 0},
                                    {1, 3, 2, 5, 0},
                                    {2, 4, 2, 1, 4}};
            int[] path1 = new int[]{1,8,3,2,1};
            int sum1 = 15;
            yield return new object[] { array1, sum1, path1 };

            int[,] array2 = new int[,]{ {1, 0, 0, 0},
                                        {8, 9, 0, 0},
                                        {1, 5, 9, 0},
                                        {4, 5, 2, 3}};
            int sum2 = 16;
            int[] path2 = new int[] {1, 8, 5, 2};
            yield return new object[] { array2, sum2, path2 };

            int[,] array3 = new int[,]{ {1, 0, 0, 0},
                                        {2, 2, 0, 0},
                                        {1, 1, 1, 0},
                                        {2, 2, 2, 2}};
            int sum3 = 6;
            int[] path3 = new int[] {1, 2, 1, 2};
            yield return new object[] { array3, sum3, path3 };

            int[,] array4 = new int[,]{ {1, 0, 0, 0},
                                        {2, 2, 0, 0},
                                        {1, 1, 8, 0},
                                        {2, 2, 2, 2}};
            int sum4 = 6;
            int[] path4 = new int[] {1, 2, 1, 2};
            yield return new object[] { array4, sum4, path4 };

            int[,] array5 = new int[,]{ {2, 0, 0, 0},
                                        {3, 3, 0, 0},
                                        {2, 1, 8, 0},
                                        {1, 2, 2, 8}};
            int sum5 = 8;
            int[] path5 = new int[] {2, 3, 2, 1};
            yield return new object[] { array5, sum5, path5 };
            
            yield return new object[] { new int[,]{{1}}, 1, new int[]{1}};
        } 



        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestFindMaxPath(int[,] pyramid, int max_sum, int[] path)
        {
            var (result_max_sum, result_path) = PyramidSolver.FindMaxPath(pyramid);

            Assert.Equal(max_sum, result_max_sum);
            Assert.True(path.SequenceEqual(result_path));
        }
    }
}
