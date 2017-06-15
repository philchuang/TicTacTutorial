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
        /// The player whose move it is
        /// </summary>
        public Player PlayerTurn { get; set; }

        /// <summary>
        /// Whether or not the game is finished
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Whether or not the game is a draw
        /// </summary>
        public bool IsDraw { get; set; }

        /// <summary>
        /// The player that won the game
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// The game board
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Makes a move for the current Player onto the given square
        /// </summary>
        /// <param name="square">the square #1-9</param>
        /// <returns>whether or not the move was successful</returns>
        public bool MakeMove(int square)
        {
            if (square < 1 || square > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(square), $"Expected a number 1-9, got {square}");
            }

            if (this.Board[square] != null) return false;
            this.Board[square] = this.PlayerTurn.Mark;

            CheckIfGameIsFinished();
            SwitchPlayerTurn();
            return true;
        }

        private void CheckIfGameIsFinished()
        {
            // top across victory
            if (this.Board[1] != null
                && this.Board[1] == this.Board[2]
                && this.Board[1] == this.Board[3])
            {
                FinishAsVictory(this.PlayerTurn);
                return;
            }

            // no other victory conditions have been detected, so check to see if all squares are filled
            if (this.Board[1] != null && this.Board[2] != null && this.Board[3] != null
                && this.Board[4] != null && this.Board[5] != null && this.Board[6] != null
                && this.Board[7] != null && this.Board[8] != null && this.Board[9] != null)
            {
                FinishAsDraw();
            }
        }

        /// <summary>
        /// Finishes the game as a Victory
        /// </summary>
        /// <param name="player">the winning player</param>
        private void FinishAsVictory(Player player)
        {
            this.IsFinished = true;
            this.IsDraw = false;
            this.PlayerTurn = null;
            this.Winner = player;
        }

        /// <summary>
        /// Finishes the game as a Draw
        /// </summary>
        private void FinishAsDraw()
        {
            this.IsFinished = true;
            this.IsDraw = true;
            this.PlayerTurn = null;
            this.Winner = null;
        }

        /// <summary>
        /// Switches the current Player
        /// </summary>
        private void SwitchPlayerTurn()
        {
            if (this.IsFinished) return;

            if (ReferenceEquals(this.PlayerTurn, this.Player1))
            {
                this.PlayerTurn = this.Player2;
            }
            else
            {
                this.PlayerTurn = this.Player1;
            }
        }
    }
}
