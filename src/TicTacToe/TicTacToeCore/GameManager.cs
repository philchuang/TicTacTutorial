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
            return new Game
            {
                Player1 = new Player
                {
                    Mark = 'X',
                    Name = "Player 1",
                },
                Player2 = new Player
                {
                    Mark = 'O',
                    Name = "Player 2",
                },
                PlayerTurn = "Player 1",
                IsFinished = false,
                IsDraw = false,
                Winner = null,
                Board = new Board
                {
                    Square1 = null,
                    Square2 = null,
                    Square3 = null,
                    Square4 = null,
                    Square5 = null,
                    Square6 = null,
                    Square7 = null,
                    Square8 = null,
                    Square9 = null,
                }
            };
        }
    }
}
