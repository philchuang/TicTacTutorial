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
        public Player Player1 { get; internal set; }

        /// <summary>
        /// The O player
        /// </summary>
        public Player Player2 { get; internal set; }

        /// <summary>
        /// The player whose move it is
        /// </summary>
        public Player PlayerTurn { get; internal set; }

        /// <summary>
        /// Whether or not the game is finished
        /// </summary>
        public bool IsFinished { get; private set; }

        /// <summary>
        /// Whether or not the game is a draw
        /// </summary>
        public bool IsDraw { get; private set; }

        /// <summary>
        /// The player that won the game
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// The game board
        /// </summary>
        public Board Board { get; }

        public Game()
        {
            this.Board = new Board();
        }

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
            if (this.Board.HasSameMarks(Board.TopRowSquares)
                || this.Board.HasSameMarks(Board.MiddleRowSquares)
                || this.Board.HasSameMarks(Board.BottomRowSquares)
                || this.Board.HasSameMarks(Board.LeftColumnSquares)
                || this.Board.HasSameMarks(Board.MiddleColumnSquares)
                || this.Board.HasSameMarks(Board.RightColumnSquares)
                || this.Board.HasSameMarks(Board.DownRightDiagonalSquares)
                || this.Board.HasSameMarks(Board.DownLeftDiagonalSquares))
            {
                FinishAsVictory(this.PlayerTurn);
                return;
            }

            // no other victory conditions have been detected, so check to see if all squares are filled
            if (this.Board.IsFilled())
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
