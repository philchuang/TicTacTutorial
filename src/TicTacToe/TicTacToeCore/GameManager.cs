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
            var player1 = new Player("Player 1", 'X');
            var player2 = new Player("Player 2", 'O');

            return new Game
            {
                Player1 = player1,
                Player2 = player2,
                PlayerTurn = player1,
            };
        }
    }
}
