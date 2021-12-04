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
            // Day1Part1();
            // Day1Part2();
            // Day2Part1();
            // Day2Part2();
            // Day3Part1();
            // Day3Part2();
            Day4Part1();
            Day4Part2();
        }
        
        private static void Day4Part2()
        {
            var (numbers, boards) = GetDay4PuzzleInput();
            var boardsInCompletion = new List<Board>();

            foreach (var number in numbers)
            {
                foreach (var board in boards.ToArray())
                {
                    board.AddNumber(number);
                    if (board.Point <= 0) continue;
                    
                    boardsInCompletion.Add(board);
                    boards.Remove(board);
                }
            }
            
            Console.WriteLine($"Day4 Part2: { boardsInCompletion.Last().Point }");
        }
        
        private static void Day4Part1()
        {
            var (numbers, boards) = GetDay4PuzzleInput();
            var boardsInCompletion = new List<Board>();

            foreach (var number in numbers)
            {
                foreach (var board in boards.ToArray())
                {
                    board.AddNumber(number);
                    if (board.Point <= 0) continue;
                    
                    boardsInCompletion.Add(board);
                    boards.Remove(board);
                }
            }
            
            Console.WriteLine($"Day4 Part1: { boardsInCompletion.First().Point }");
        }

        private static void Day3Part2()
        {
            var puzzleInput = GetDay3PuzzleInput();

            var oxygenArray = puzzleInput.ToArray();
            var co2ScrubberArray = puzzleInput.ToArray();

            for (var i = 0; i < puzzleInput.First().Length; i++)
            {
                if (oxygenArray.Length == 1)
                {
                    break;
                }

                var zeroCounter = 0;
                var oneCounter = 0;

                foreach (var input in oxygenArray)
                {
                    var bit = input.ElementAt(i) == '0' ? zeroCounter++ : oneCounter++;
                }

                if (zeroCounter > oneCounter)
                {
                    oxygenArray = oxygenArray.Where(x => x.ElementAt(i) == '0').ToArray();
                }
                else if (zeroCounter == oneCounter)
                {
                    oxygenArray = oxygenArray.Where(x => x.ElementAt(i) == '1').ToArray();
                }
                else
                {
                    oxygenArray = oxygenArray.Where(x => x.ElementAt(i) == '1').ToArray();
                }
            }

            for (var i = 0; i < puzzleInput.First().Length; i++)
            {
                if (co2ScrubberArray.Length == 1)
                {
                    break;
                }

                var zeroCounter = 0;
                var oneCounter = 0;

                foreach (var input in co2ScrubberArray)
                {
                    var bit = input.ElementAt(i) == '0' ? zeroCounter++ : oneCounter++;
                }

                if (zeroCounter > oneCounter)
                {
                    co2ScrubberArray = co2ScrubberArray.Where(x => x.ElementAt(i) == '1').ToArray();
                }
                else if (zeroCounter == oneCounter)
                {
                    co2ScrubberArray = co2ScrubberArray.Where(x => x.ElementAt(i) == '0').ToArray();
                }
                else
                {
                    co2ScrubberArray = co2ScrubberArray.Where(x => x.ElementAt(i) == '0').ToArray();
                }
            }

            Console.WriteLine($"Day3 Part2: {Convert.ToInt32(oxygenArray[0], 2) * Convert.ToInt32(co2ScrubberArray[0], 2)}");
        }

        private static void Day3Part1()
        {
            var puzzleInput = GetDay3PuzzleInput();

            var gammaBinary = "";
            var epsilonBinary = "";

            for (var i = 0; i < puzzleInput.First().Length; i++)
            {
                var zeroCounter = 0;
                var oneCounter = 0;

                foreach (var input in puzzleInput)
                {
                    var i1 = input.ElementAt(i) == '0' ? zeroCounter++ : oneCounter++;
                }

                gammaBinary += zeroCounter > oneCounter ? "0" : "1";
                epsilonBinary += zeroCounter < oneCounter ? "0" : "1";
            }

            Console.WriteLine($"Day3 Par1: {Convert.ToInt32(gammaBinary, 2) * Convert.ToInt32(epsilonBinary, 2)}");
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

        private static IEnumerable<string> GetDay3PuzzleInput()
        {
            return File.ReadLines("../../../Day3Input.txt");
        }
        
        private static (IEnumerable<int>, List<Board>) GetDay4PuzzleInput()
        {
            var input = File.ReadLines("../../../Day4Input.txt");

            var numbers = input.ElementAt(0).Split(',').Select(x => Convert.ToInt32(x));

            var boards = input.Skip(2).Chunk(6).Select(x => new Board(x));

            return (numbers, boards.ToList());
        }
    }
}
