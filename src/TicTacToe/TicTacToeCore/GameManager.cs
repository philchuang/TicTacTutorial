using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class GameManager
    {
        public Game CreateNew()
        {
            var player1 = new Player
            {
                Mark = 'X',
                Name = "Player 1",
            };
            var player2 = new Player
            {
                Mark = 'O',
                Name = "Player 2",
            };

            return new Game
            {
                Player1 = player1,
                Player2 = player2,
                PlayerTurn = player1,
                IsFinished = false,
                IsDraw = false,
                Winner = null,
                Board = new Board(),
            };
        }
    }
}
