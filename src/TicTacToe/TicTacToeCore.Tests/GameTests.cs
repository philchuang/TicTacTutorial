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
        public void Game_MakeMove_with_empty_board_should_allow_move_for_square_1()
        {
            var moveSuccess = game.MakeMove(1);
            Assert.IsTrue(moveSuccess, nameof(moveSuccess));
            Assert.AreEqual('X', game.Board.Square1);
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_allow_move_for_square_2()
        {
            var moveSuccess = game.MakeMove(2);
            Assert.IsTrue(moveSuccess, nameof(moveSuccess));
            Assert.AreEqual('X', game.Board.Square2);
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_allow_move_for_square_3()
        {
            var moveSuccess = game.MakeMove(3);
            Assert.IsTrue(moveSuccess, nameof(moveSuccess));
            Assert.AreEqual('X', game.Board.Square3);
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
        public void Game_MakeMove_with_empty_board_should_deny_move_for_square_1()
        {
            // initial move
            var move1Success = game.MakeMove(1);
            Assert.IsTrue(move1Success, nameof(move1Success));
            Assert.AreEqual('X', game.Board.Square1);

            // following move
            var move2Success = game.MakeMove(1);
            Assert.IsFalse(move2Success, nameof(move2Success));
            Assert.AreEqual('X', game.Board.Square1);
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_deny_move_for_square_2()
        {
            // initial move
            var move1Success = game.MakeMove(2);
            Assert.IsTrue(move1Success, nameof(move1Success));
            Assert.AreEqual('X', game.Board.Square2);

            // following move
            var move2Success = game.MakeMove(2);
            Assert.IsFalse(move2Success, nameof(move2Success));
            Assert.AreEqual('X', game.Board.Square2);
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_deny_move_for_square_3()
        {
            // initial move
            var move1Success = game.MakeMove(3);
            Assert.IsTrue(move1Success, nameof(move1Success));
            Assert.AreEqual('X', game.Board.Square3);

            // following move
            var move2Success = game.MakeMove(3);
            Assert.IsFalse(move2Success, nameof(move2Success));
            Assert.AreEqual('X', game.Board.Square3);
        }

        [TestMethod]
        public void Game_MakeMove_after_winning_move_should_update_fields()
        {
            // handles top across as X
            var moves = new[] {1, 4, 2, 5, 3};

            // iterate over the moves and test unfinished status
            for (var moveIdx = 0; moveIdx < moves.Length; moveIdx++)
            {
                var move = moves[moveIdx];
                var moveSuccess = game.MakeMove(move);
                Assert.IsTrue(moveSuccess, nameof(moveSuccess));

                if (moveIdx + 1 != moves.Length)
                {
                    // not the final move
                    Assert.IsFalse(game.IsFinished, "game.IsFinished");
                    Assert.IsFalse(game.IsDraw, "game.IsDraw");
                    Assert.IsNotNull(game.PlayerTurn, "game.PlayerTurn");
                    Assert.IsNull(game.Winner, "game.Winner");
                }
            }

            // test finished status
            Assert.IsTrue(game.IsFinished, "game.IsFinished");
            Assert.IsFalse(game.IsDraw, "game.IsDraw");
            Assert.IsNull(game.PlayerTurn, "game.PlayerTurn");
            Assert.AreEqual(game.Player1, game.Winner, "game.Winner");
        }

        [TestMethod]
        public void Game_MakeMove_after_draw_move_should_update_fields()
        {
            // maybe try a couple more cases but don't think we should determine them all
            var moves = new[] { 1, 4, 2, 5, 6, 3, 7, 8, 9 };

            // iterate over the moves and test unfinished status
            for (var moveIdx = 0; moveIdx < moves.Length; moveIdx++)
            {
                var move = moves[moveIdx];
                var moveSuccess = game.MakeMove(move);
                Assert.IsTrue(moveSuccess, nameof(moveSuccess));

                if (moveIdx + 1 != moves.Length)
                {
                    // not the final move
                    Assert.IsFalse(game.IsFinished, "game.IsFinished");
                    Assert.IsFalse(game.IsDraw, "game.IsDraw");
                    Assert.IsNotNull(game.PlayerTurn, "game.PlayerTurn");
                    Assert.IsNull(game.Winner, "game.Winner");
                }
            }

            // test finished status
            Assert.IsTrue(game.IsFinished, "game.IsFinished");
            Assert.IsTrue(game.IsDraw, "game.IsDraw");
            Assert.IsNull(game.PlayerTurn, "game.PlayerTurn");
            Assert.IsNull(game.Winner, "game.Winner");
        }
    }
}
