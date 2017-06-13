using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class GameTests
    {
        private GameManager gameMgr;
        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            gameMgr = new GameManager();
            game = gameMgr.CreateNew();
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_allow_any_sqare_and_mark_move()
        {
            var testCases = new[]
            {
                new Tuple<int, Func<Game, char?>>(1, g => g.Board.Square1),
                new Tuple<int, Func<Game, char?>>(2, g => g.Board.Square2),
                new Tuple<int, Func<Game, char?>>(3, g => g.Board.Square3),
                new Tuple<int, Func<Game, char?>>(4, g => g.Board.Square4),
                new Tuple<int, Func<Game, char?>>(5, g => g.Board.Square5),
                new Tuple<int, Func<Game, char?>>(6, g => g.Board.Square6),
                new Tuple<int, Func<Game, char?>>(7, g => g.Board.Square7),
                new Tuple<int, Func<Game, char?>>(8, g => g.Board.Square8),
                new Tuple<int, Func<Game, char?>>(9, g => g.Board.Square9),
            };

            foreach (var testCase in testCases)
            {
                game = gameMgr.CreateNew();
                var moveSuccess = game.MakeMove(testCase.Item1);
                Assert.IsTrue(moveSuccess, nameof(moveSuccess));
                Assert.AreEqual('X', testCase.Item2(game));
            }
        }

        [TestMethod]
        public void Game_MakeMove_should_change_PlayerTurn_after_MakeMove()
        {
            var player1Name = game.PlayerTurn;
            var move1Success = game.MakeMove(1);
            var player2Name = game.PlayerTurn;
            Assert.IsTrue(move1Success, nameof(move1Success));
            Assert.AreNotEqual(player1Name, player2Name, $"{nameof(player1Name)} != {nameof(player2Name)}");
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_deny_move_for_marked_space()
        {
            var testCases = new[]
            {
                new Tuple<int, Func<Game, char?>>(1, g => g.Board.Square1),
                new Tuple<int, Func<Game, char?>>(2, g => g.Board.Square2),
                new Tuple<int, Func<Game, char?>>(3, g => g.Board.Square3),
                new Tuple<int, Func<Game, char?>>(4, g => g.Board.Square4),
                new Tuple<int, Func<Game, char?>>(5, g => g.Board.Square5),
                new Tuple<int, Func<Game, char?>>(6, g => g.Board.Square6),
                new Tuple<int, Func<Game, char?>>(7, g => g.Board.Square7),
                new Tuple<int, Func<Game, char?>>(8, g => g.Board.Square8),
                new Tuple<int, Func<Game, char?>>(9, g => g.Board.Square9),
            };

            foreach (var testCase in testCases)
            {
                game = gameMgr.CreateNew();
                
                // initial move
                var move1Success = game.MakeMove(testCase.Item1);
                Assert.IsTrue(move1Success, nameof(move1Success));
                Assert.AreEqual('X', testCase.Item2(game));

                // following move
                var move2Success = game.MakeMove(testCase.Item1);
                Assert.IsFalse(move2Success, nameof(move2Success));
                Assert.AreEqual('X', testCase.Item2(game));
            }
        }

        [TestMethod]
        public void Game_MakeMove_after_winning_move_should_update_fields()
        {
            Assert.Inconclusive("Test not yet written");
        }

        [TestMethod]
        public void Game_MakeMove_after_draw_move_should_update_fields()
        {
            Assert.Inconclusive("Test not yet written");
        }

        [TestMethod]
        public void Game_MakeMove_should_detect_winning_moves()
        {
            // TODO come up with all the different win scenarios: (top across, middle across, bottom across, left down, center down, right down, diagonal right, diagonal left) x (X, O) = 16 cases
            // create them as a series of move indexes
            Assert.Inconclusive("Test not yet written");
        }
    }
}
