using System;
using Com.PhilChuang.Apps.TicTacToe.Tests.Testable;
using Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles;
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
            var gameManager = new GameManagerTestable();

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
            var gameManager = new GameManagerTestable();
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            gameManager.MakeRandomProviderOverride = () => new RandomProviderStubReturns0();

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
            var gameManager = new GameManagerTestable();
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            gameManager.MakeRandomProviderOverride = () => new RandomProviderStubReturns1();

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
            var gameManager = new GameManagerTestable();
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            var expectedReturnValueForRandomProviderGet = 1;
            var spy = new RandomProviderSpy(new RandomProviderMock { GetOverride = maxValue => expectedReturnValueForRandomProviderGet });
            gameManager.MakeRandomProviderOverride = () => spy;

            // Act
            var game = gameManager.CreateNewRandom(firstPlayer, secondPlayer);

            // Assert
            Assert.AreEqual(1, spy.GetSpy.Calls.Count, "Expected 1 call to RandomProvider.Get()");
            Assert.AreEqual(2, spy.GetSpy.Calls[0].Item1, "Expected maxValue parameter of RandomProvider.Get() call #1 to be \"2\"");
            Assert.AreEqual(expectedReturnValueForRandomProviderGet, spy.GetSpy.Calls[0].Item2, $"Expected return value of RandomProvider.Get() call #1 to be \"{expectedReturnValueForRandomProviderGet}\"");
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
            var gameManager = new GameManagerTestable();

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