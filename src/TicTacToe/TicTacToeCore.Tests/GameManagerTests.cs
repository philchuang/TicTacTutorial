using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void GameManager_CreateNew_should_return_a_new_game()
        {
            // Arrange
            var gameManager = new GameManager(null);

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

        [TestMethod]
        public void GameManager_CreateNewRandom_with_random_0_should_not_swap_players()
        {
            // Arrange
            var randomMock = new Mock<IRandomProvider>(MockBehavior.Strict);
            randomMock.Setup(m => m.Get(It.IsAny<int?>())).Returns(0);
            var gameManager = new GameManager(randomMock.Object);
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();

            // Act
            var game = gameManager.CreateNewRandom(firstPlayer, secondPlayer);

            // Assert
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Player1, "game.Player1");
            Assert.AreEqual('X', game.Player1.Mark, "game.Player1.Mark");
            Assert.AreEqual(firstPlayer, game.Player1.Name, "game.Player1.Name");
            Assert.IsNotNull(game.Player2, "game.Player2");
            Assert.AreEqual('O', game.Player2.Mark, "game.Player2.Mark");
            Assert.AreEqual(secondPlayer, game.Player2.Name, "game.Player2.Name");
        }

        [TestMethod]
        public void GameManager_CreateNewRandom_with_random_1_should_swap_players()
        {
            // Arrange
            var randomMock = new Mock<IRandomProvider>(MockBehavior.Strict);
            randomMock.Setup(m => m.Get(It.IsAny<int?>())).Returns(1);
            var gameManager = new GameManager(randomMock.Object);
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();

            // Act
            var game = gameManager.CreateNewRandom(firstPlayer, secondPlayer);

            // Assert
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Player1, "game.Player1");
            Assert.AreEqual('X', game.Player1.Mark, "game.Player1.Mark");
            Assert.AreEqual(secondPlayer, game.Player1.Name, "game.Player1.Name");
            Assert.IsNotNull(game.Player2, "game.Player2");
            Assert.AreEqual('O', game.Player2.Mark, "game.Player2.Mark");
            Assert.AreEqual(firstPlayer, game.Player2.Name, "game.Player2.Name");
        }

        [TestMethod]
        public void GameManager_CreateNewRandom_calls_RandomProvider()
        {
            // Arrange
            var expectedReturnValueForRandomProviderGet = 1;
            var randomMock = new Mock<IRandomProvider>(MockBehavior.Strict);
            randomMock.Setup(m => m.Get(It.IsAny<int?>())).Returns(expectedReturnValueForRandomProviderGet);
            var gameManager = new GameManager(randomMock.Object);
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();

            // Act
            var game = gameManager.CreateNewRandom(firstPlayer, secondPlayer);

            // Assert
            randomMock.Verify(m => m.Get(2), Times.Once());
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GameManager_CreateNewRandom_should_swap_players_50_pct_of_the_time()
        {
            // need a large number of runs to ensure a smooth statistical distribution
            var testRuns = 10000;
            var numSwapped = 0;
            var numNotSwapped = 0;
            var player1 = Guid.NewGuid().ToString();
            var player2 = Guid.NewGuid().ToString();
            var gameManager = new GameManager(new RandomProvider());

            for (var i = 0; i < testRuns; i++)
            {
                var game = gameManager.CreateNewRandom(player1, player2);

                if (game.Player1.Name == player1)
                {
                    numNotSwapped++;
                }
                else
                {
                    numSwapped++;
                }
            }

            // expect 1:1
            var expectedRatio = 0.5d;
            // but give it 10% margin of error either way
            var marginOfError = 0.1d;

            var actualRatio = Math.Abs(numSwapped / (double) testRuns);

            Console.WriteLine($"Swapped: {numSwapped}, not swapped: {numNotSwapped}, total: {testRuns}, ratio: {actualRatio:0.000}");

            Assert.IsTrue(Math.Abs(actualRatio-expectedRatio) <= marginOfError, $"Expected a ratio of {expectedRatio:0.000} but got {actualRatio:0.000}");
        }
    }
}