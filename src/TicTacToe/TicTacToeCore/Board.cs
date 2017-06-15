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
    }
}
