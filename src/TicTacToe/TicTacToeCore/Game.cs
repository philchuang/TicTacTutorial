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

        /// <summary>
        /// Makes a move for the current Player onto the given square
        /// </summary>
        /// <param name="square">the square #1-9</param>
        /// <returns>whether or not the move was successful</returns>
        public bool MakeMove(int square)
        {
            switch (square)
            {
                case 1:
                    if (this.Board.Square1 != null) return false;
                    this.Board.Square1 = this.GetCurrentPlayer().Mark;
                    break;
                case 2:
                    if (this.Board.Square2 != null) return false;
                    this.Board.Square2 = this.GetCurrentPlayer().Mark;
                    break;
                case 3:
                    if (this.Board.Square3 != null) return false;
                    this.Board.Square3 = this.GetCurrentPlayer().Mark;
                    break;
                case 4:
                    if (this.Board.Square4 != null) return false;
                    this.Board.Square4 = this.GetCurrentPlayer().Mark;
                    break;
                case 5:
                    if (this.Board.Square5 != null) return false;
                    this.Board.Square5 = this.GetCurrentPlayer().Mark;
                    break;
                case 6:
                    if (this.Board.Square6 != null) return false;
                    this.Board.Square6 = this.GetCurrentPlayer().Mark;
                    break;
                case 7:
                    if (this.Board.Square7 != null) return false;
                    this.Board.Square7 = this.GetCurrentPlayer().Mark;
                    break;
                case 8:
                    if (this.Board.Square8 != null) return false;
                    this.Board.Square8 = this.GetCurrentPlayer().Mark;
                    break;
                case 9:
                    if (this.Board.Square9 != null) return false;
                    this.Board.Square9 = this.GetCurrentPlayer().Mark;
                    break;
                default:
                    return false;
            }

            CheckIfGameIsFinished();
            SwitchPlayerTurn();
            return true;
        }

        private Player GetCurrentPlayer()
        {
            return this.GetPlayerByName(this.PlayerTurn);
        }

        private Player GetPlayerByName(string name)
        {
            if (name == this.Player1.Name)
            {
                return this.Player1;
            }

            return this.Player2;
        }

        private void CheckIfGameIsFinished()
        {
            if (this.Board.Square1 != null
                && this.Board.Square1 == this.Board.Square2
                && this.Board.Square1 == this.Board.Square3)
            {
                FinishAsVictory(this.PlayerTurn);
                return;
            }

            if (this.Board.Square1 != null && this.Board.Square2 != null && this.Board.Square3 != null
                && this.Board.Square4 != null && this.Board.Square5 != null && this.Board.Square6 != null
                && this.Board.Square7 != null && this.Board.Square8 != null && this.Board.Square9 != null)
            {
                FinishAsDraw();
            }
        }

        /// <summary>
        /// Finishes the game as a Victory
        /// </summary>
        /// <param name="playerName">the winning player name</param>
        private void FinishAsVictory(string playerName)
        {
            this.IsFinished = true;
            this.IsDraw = false;
            this.PlayerTurn = null;
            this.Winner = playerName;
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

            if (string.Equals(this.PlayerTurn, this.Player1.Name))
            {
                this.PlayerTurn = this.Player2.Name;
            }
            else
            {
                this.PlayerTurn = this.Player1.Name;
            }
        }
    }
}
