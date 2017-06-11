using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class Game
    {
        /// <summary>
        /// The X player
        /// </summary>
        public Player Player1 { get; set; }

        /// <summary>
        /// The O player
        /// </summary>
        public Player Player2 { get; set; }

        /// <summary>
        /// The name of the player whose move it is
        /// </summary>
        public string PlayerTurn { get; set; }

        /// <summary>
        /// Whether or not the game is finished
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Whether or not the game is a draw
        /// </summary>
        public bool IsDraw { get; set; }

        /// <summary>
        /// The name of the player that won the game
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// The game board
        /// </summary>
        public Board Board { get; set; }
    }
}
