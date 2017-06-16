using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class Board
    {
        private readonly char?[] mySquares = new char?[9];

        /// <summary>
        /// Indexer to retrieve any square on the board, indexes 1-9
        /// </summary>
        /// <param name="idx">a number 1-9</param>
        /// <returns>the mark of the player who owns the square</returns>
        public char? this[int idx]
        {
            get
            {
                if (idx < 1 || idx > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx), $"Expected a number 1-9, got {idx}");
                }

                return mySquares[idx - 1];
            }
            set
            {
                if (idx < 1 || idx > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx), $"Expected a number 1-9, got {idx}");
                }

                mySquares[idx - 1] = value;
            }
        }

        public static readonly IReadOnlyList<int> TopRowSquares = new[] {1, 2, 3};
        public static readonly IReadOnlyList<int> MiddleRowSquares = new[] {4, 5, 6};
        public static readonly IReadOnlyList<int> BottomRowSquares = new[] {7, 8, 9};
        public static readonly IReadOnlyList<int> LeftColumnSquares = new[] {1, 4, 7};
        public static readonly IReadOnlyList<int> MiddleColumnSquares = new[] {2, 5, 8};
        public static readonly IReadOnlyList<int> RightColumnSquares = new[] {3, 6, 9};
        public static readonly IReadOnlyList<int> DownRightDiagonalSquares = new[] {1, 5, 9};
        public static readonly IReadOnlyList<int> DownLeftDiagonalSquares = new[] {3, 5, 7};

        public bool HasSameMarks(IEnumerable<int> squares)
        {
            char? prevMark = null;
            foreach (var square in squares)
            {
                if (this[square] == null) return false;

                if (prevMark == null)
                {
                    prevMark = this[square];
                    continue;
                }

                if (this[square] != prevMark) return false;

                prevMark = this[square];
            }

            return true;
        }

        public bool IsFilled()
        {
            return mySquares.All(c => c != null);
        }
    }
}
