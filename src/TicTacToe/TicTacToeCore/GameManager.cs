using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class GameManager
    {
        private readonly IRandomProvider RandomProvider;

        public GameManager(IRandomProvider rand)
        {
            RandomProvider = rand;
        }

        public Game CreateNew(string player1Name = "Player 1", string player2Name = "Player 2")
        {
            return CreateNew(new Player(player1Name, 'X'), new Player(player2Name, 'O'));
        }

        public Game CreateNew(Player player1, Player player2)
        {
            return new Game
            {
                Player1 = player1,
                Player2 = player2,
                PlayerTurn = player1,
            };
        }

        public Game CreateNewRandom(string playerName, string otherPlayerName)
        {
            var swap = this.RandomProvider.Get(2) == 1;
            var player1 = new Player(swap ? otherPlayerName : playerName, 'X');
            var player2 = new Player(swap ? playerName : otherPlayerName, 'O');

            return CreateNew(player1, player2);
        }
    }
}
