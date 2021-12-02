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
            Day1Part2();
            Day2Part1();
            Day2Part2();
        }

        private static void Day2Part2()
        {
            var input = GetDay2PuzzleInput();

            var horizontalPos = 0;
            var verticalPos = 0;
            var aim = 0;

            foreach (var (item1, item2) in input)
            {
                switch (item1)
                {
                    case 0:
                        aim -= item2;
                        break;
                    case 1:
                        aim += item2;
                        break;
                    case 2:
                        horizontalPos += item2;
                        verticalPos += aim * item2;
                        break;
                }
            }

            Console.WriteLine($"Day2 Part2: {horizontalPos * verticalPos}");
        }

        private static void Day2Part1()
        {
            var input = GetDay2PuzzleInput();

            var horizontalPos = 0;
            var verticalPos = 0;

            foreach (var (item1, item2) in input)
            {
                switch (item1)
                {
                    case 0:
                        horizontalPos -= item2;
                        break;
                    case 1:
                        horizontalPos += item2;
                        break;
                    case 2:
                        verticalPos += item2;
                        break;
                }
            }

            Console.WriteLine($"Day2 Part1: {horizontalPos * verticalPos}");
        }

        private static void Day1Part2()
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

        private static IEnumerable<Tuple<int, int>> GetDay2PuzzleInput()
        {
            return File.ReadLines("../../../Day2Input.txt").Select(x =>
            {
                var items = x.Trim().Split(' ');

                return items[0] switch
                {
                    "up" => Tuple.Create(0, Convert.ToInt32(items[1])),
                    "down" => Tuple.Create(1, Convert.ToInt32(items[1])),
                    "forward" => Tuple.Create(2, Convert.ToInt32(items[1])),
                    _ => Tuple.Create(0, 0)
                };
            });
        }
    }
}
