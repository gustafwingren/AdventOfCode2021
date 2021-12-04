using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Board
    {
        public int Point { get; private set; }
        
        private readonly List<Cell> _cells;

        private IEnumerable<Cell> CellsInRow(int iRow) => Enumerable.Range(0, 5).Select(x => _cells[iRow * 5 + x]);

        private IEnumerable<Cell> CellsInCol(int iCol) => Enumerable.Range(0, 5).Select(x => _cells[x * 5 + iCol]);

        public Board(IEnumerable<string> input)
        {
            _cells = string.Join(" ", input).Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Cell(Convert.ToInt32(x))).ToList();
        }

        public void AddNumber(int number)
        {
            var cell = _cells.FindIndex(x => x.Number == number);

            if (cell < 0) return;
            {
                _cells[cell] = _cells[cell] with {Marked = true};

                for (var i = 0; i < 5; i++)
                {
                    if (!CellsInRow(i).All(x => x.Marked) && !CellsInCol(i).All(x => x.Marked)) continue;
                    {
                        var unmarkedNumbers = _cells.Where(x => !x.Marked).Select(x => x.Number);

                        Point = number * unmarkedNumbers.Sum();
                    }
                }
            }
        }
    }

    public record Cell(int Number, bool Marked = false);
}