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
