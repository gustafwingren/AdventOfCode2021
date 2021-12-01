using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var entriesArray = entries as int[] ?? entries.ToArray();
            var pairs = entriesArray.Select((t, i) => entriesArray.Skip(i).Take(3)).Select(pair => pair.Sum()).ToList();

            var enumerable = IsDepthIncreased(pairs);

            Console.WriteLine($"Day1 Part 2: {enumerable.Count(x => x)}");
        }

        private static void Day1Part1()
        {
            var entries = GetDay1PuzzleInput();
            var entriesArray = entries as int[] ?? entries.ToArray();
            var enumerable = IsDepthIncreased(entriesArray);

            Console.WriteLine($"Day1 Part 1: {enumerable.Count(x => x)}");
        }

        private static IEnumerable<bool> IsDepthIncreased(IReadOnlyCollection<int> pairs)
        {
            var enumerable = pairs.Select((x, index) =>
            {
                if (index == 0)
                {
                    return false;
                }

                return x > pairs.ElementAt(index - 1);
            });

            return enumerable;
        }

        private static IEnumerable<int> GetDay1PuzzleInput()
        {
            return File.ReadLines("../../../Day1Input.txt").Select(x => Convert.ToInt32(x));
        }
    }
}
