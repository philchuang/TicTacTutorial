using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        [TestCategory("E2E")]
        public void Can_play_a_game_to_completion_where_X_wins()
        {
            var mgr = new GameManager();
            var player1 = Guid.NewGuid().ToString();
            var player2 = Guid.NewGuid().ToString();
            var game = mgr.CreateNew(player1, player2);

            var moves = new[]
            {
                // _|_|_
                // _|_|_
                //  | | 
                5,
                // _|_|_
                // _|X|_
                //  | | 
                2,
                // _|O|_
                // _|X|_
                //  | | 
                1,
                // X|O|_
                // _|X|_
                //  | | 
                9,
                // X|O|_
                // _|X|_
                //  | |O
                7,
                // X|O|_
                // _|X|_
                // X| |O
                4,
                // X|O|_
                // O|X|_
                // X| |O
                3,
                // X|O|X
                // O|X|_
                // X| |O
            };

            var expectedWinnerName = player1;
            var expectedWinnerMark = 'X';
            var expectedBoard = new char?[]
            {
                'X', 'O', 'X',
                'O', 'X', null,
                'X', null, 'O'
            };

            foreach (var move in moves)
            {
                game.MakeMove(move);
            }

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(expectedWinnerName, game.Winner.Name, nameof(game.Winner.Name));
            Assert.AreEqual(expectedWinnerMark, game.Winner.Mark, nameof(game.Winner.Mark));

            for (var i = 1; i <= 9; i++)
            {
                Assert.AreEqual(expectedBoard[i-1], game.Board[i], $"Expected {expectedBoard[i-1]} at position {i}, got {game.Board[i]}");
            }
        }
    }
}
