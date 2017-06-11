using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class Board
    {
        /// <summary>
        /// The mark of the player who owns square 1 (top left)
        /// </summary>
        public char? Square1 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 2 (top middle)
        /// </summary>
        public char? Square2 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 3 (top right)
        /// </summary>
        public char? Square3 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 4 (center left)
        /// </summary>
        public char? Square4 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 5 (center middle)
        /// </summary>
        public char? Square5 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 6 (center right)
        /// </summary>
        public char? Square6 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 7 (bottom left)
        /// </summary>
        public char? Square7 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 8 (bottom middle)
        /// </summary>
        public char? Square8 { get; set; }

        /// <summary>
        /// The mark of the player who owns square 9 (bottom right)
        /// </summary>
        public char? Square9 { get; set; }
    }
}
