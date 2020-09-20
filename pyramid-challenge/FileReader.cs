using System;
using System.Collections.Generic;

namespace pyramid_challenge 
{
    public class FileReader
    {
        public static int[,] Read(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            var N = lines.Length;
            var array = new int[N, N];

            int line_nr = 0;
            foreach (var line in lines)
            {
                var splitted_line = line.Split(' ');
                for (var i = 0; i < splitted_line.Length; i++)
                {
                    array[line_nr, i] = Int32.Parse(splitted_line[i]);
                }
                line_nr++;
            }

            return array;
        }
    }
}