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
            gameManager = new GameManager();
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
            Assert.AreEqual(game.Player1.Name, game.PlayerTurn, "game.PlayerTurn");
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
            Assert.IsNull(game.Board.Square1, "game.Board.Square1");
            Assert.IsNull(game.Board.Square2, "game.Board.Square2");
            Assert.IsNull(game.Board.Square3, "game.Board.Square3");
            Assert.IsNull(game.Board.Square4, "game.Board.Square4");
            Assert.IsNull(game.Board.Square5, "game.Board.Square5");
            Assert.IsNull(game.Board.Square6, "game.Board.Square6");
            Assert.IsNull(game.Board.Square7, "game.Board.Square7");
            Assert.IsNull(game.Board.Square8, "game.Board.Square8");
            Assert.IsNull(game.Board.Square9, "game.Board.Square9");
        }
    }
}
