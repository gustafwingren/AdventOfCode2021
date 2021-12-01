using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Int32;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1Part1();
            Day2Part2();
        }

        private static void Day2Part2()
        {
            var entries = GetDay1PuzzleInput();
            var pairs = new List<int>();

            for (var i = 0; i < entries.Count(); i++)
            {
                var pair = entries.Skip(i).Take(3);
                pairs.Add(pair.Sum());
            }

            var enumerable = pairs.Select((x, index) =>
            {
                if (index == 0)
                {
                    return 0;
                }

                return x > pairs.ElementAt(index - 1) ? 1 : 0;
            });

            Console.WriteLine($"Day1 Part 2: {enumerable.Count(x => x == 1)}");
        }

        private static void Day1Part1()
        {
            var entries = GetDay1PuzzleInput();

            var entriesArray = entries as int[] ?? entries.ToArray();
            var enumerable = entriesArray.Select((x, index) =>
            {
                if (index == 0)
                {
                    return 0;
                }

                return x > entriesArray.ElementAt(index - 1) ? 1 : 0;
            });
            Console.WriteLine($"Day1 Part 1: {enumerable.Count(x => x == 1)}");
        }

        private static IEnumerable<int> GetDay1PuzzleInput()
        {
            return File.ReadLines("../../../Day1Input.txt").Select(x => Convert.ToInt32(x));
        }
    }
}
