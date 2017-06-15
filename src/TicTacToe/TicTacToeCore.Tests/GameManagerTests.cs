using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void GameManager_CreateNew_should_return_a_new_game()
        {
            // Arrange
            var gameManager = new GameManager();

            // Act
            var game = gameManager.CreateNew();

            // Assert
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Player1, "game.Player1");
            Assert.AreEqual('X', game.Player1.Mark, "game.Player1.Mark");
            Assert.AreEqual("Player 1", game.Player1.Name, "game.Player1.Name");
            Assert.IsNotNull(game.Player2, "game.Player2");
            Assert.AreEqual('O', game.Player2.Mark, "game.Player2.Mark");
            Assert.AreEqual("Player 2", game.Player2.Name, "game.Player2.Name");
            Assert.AreEqual(game.Player1, game.PlayerTurn, "game.PlayerTurn");
            Assert.IsFalse(game.IsFinished, "game.IsFinished");
            Assert.IsFalse(game.IsDraw, "game.IsDraw");
            Assert.IsNull(game.Winner, "game.Winner");
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
