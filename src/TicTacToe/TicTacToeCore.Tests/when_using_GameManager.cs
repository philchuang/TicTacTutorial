using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class when_using_GameManager_CreateNew : SpecBase
    {
        protected GameManager gameManager;
        protected Game game;

        protected override void Establish_context()
        {
            gameManager = new GameManager(null);
        }

        protected override void Because_of()
        {
            game = gameManager.CreateNew();
        }

        [TestMethod]
        public void then_it_should_return_a_new_instance()
        {
            Assert.IsNotNull(game, "game");
        }

        [TestMethod]
        public void then_Player1_should_be_initialized()
        {
            Assert.IsNotNull(game.Player1, "game.Player1");
            Assert.AreEqual('X', game.Player1.Mark, "game.Player1.Mark");
            Assert.AreEqual("Player 1", game.Player1.Name, "game.Player1.Name");
        }

        [TestMethod]
        public void then_Player2_should_be_initialized()
        {
            Assert.IsNotNull(game.Player2, "game.Player2");
            Assert.AreEqual('O', game.Player2.Mark, "game.Player2.Mark");
            Assert.AreEqual("Player 2", game.Player2.Name, "game.Player2.Name");
        }

        [TestMethod]
        public void then_PlayerTurn_should_be_Player_1()
        {
            Assert.AreEqual(game.Player1, game.PlayerTurn, "game.PlayerTurn");
        }

        [TestMethod]
        public void then_IsFinished_should_be_false()
        {
            Assert.IsFalse(game.IsFinished, "game.IsFinished");
        }

        [TestMethod]
        public void then_IsDraw_should_be_false()
        {
            Assert.IsFalse(game.IsDraw, "game.IsDraw");
        }

        [TestMethod]
        public void then_Winner_should_be_null()
        {
            Assert.IsNull(game.Winner, "game.Winner");
        }

        [TestMethod]
        public void then_Board_should_be_initialized()
        {
            Assert.IsNotNull(game.Board, "game.Board");
            Assert.IsNull(game.Board[1], "game.Board[1]");
            Assert.IsNull(game.Board[2], "game.Board[2]");
            Assert.IsNull(game.Board[3], "game.Board[3]");
            Assert.IsNull(game.Board[4], "game.Board[4]");
            Assert.IsNull(game.Board[5], "game.Board[5]");
            Assert.IsNull(game.Board[6], "game.Board[6]");
            Assert.IsNull(game.Board[7], "game.Board[7]");
            Assert.IsNull(game.Board[8], "game.Board[8]");
            Assert.IsNull(game.Board[9], "game.Board[9]");
        }
    }
}
