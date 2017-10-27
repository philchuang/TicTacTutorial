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
            gameMgr = new GameManager(null);
            game = gameMgr.CreateNew();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Game_MakeMove_with_invalid_square_number_should_throw_exception()
        {
            game.MakeMove(10);
        }

        [TestMethod]
        public void Game_MakeMove_with_empty_board_should_allow_move_for_any_square()
        {
            TestCaseRunner.Execute(
                Enumerable.Range(1, 9),
                square =>
                {
                    game = gameMgr.CreateNew();
                    var moveSuccess = game.MakeMove(square);
                    Assert.IsTrue(moveSuccess, nameof(moveSuccess));
                    Assert.AreEqual('X', game.Board[square], $"Failed for square {square}");
                });
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
        public void Game_MakeMove_with_filled_square_should_deny_move_for_same_square()
        {
            TestCaseRunner.Execute(
                Enumerable.Range(1, 9),
                square =>
                {
                    game = gameMgr.CreateNew();

                    // initial move
                    var move1Success = game.MakeMove(square);
                    Assert.IsTrue(move1Success, $"initial move to square {square} should have been successful.");
                    Assert.AreEqual('X', game.Board[square], $"square {square} should be marked 'X'");

                    // following move
                    var move2Success = game.MakeMove(square);
                    Assert.IsFalse(move2Success, $"following move to square {square} should NOT have been successful.");
                    Assert.AreEqual('X', game.Board[square], $"square {square} should STILL be marked 'X'");
                });
        }

        [TestMethod]
        public void Game_MakeMove_after_winning_move_should_update_fields()
        {
            // different win scenarios: (top across, middle across, bottom across, left down, center down, right down, diagonal right, diagonal left) x (X, O) = 16 cases
            var testCases = new[]
            {
                new Tuple<IList<int>, char?>(new[] { 1, 4, 2, 5, 3 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 4, 1, 5, 2, 6 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 7, 1, 8, 2, 9 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 1, 2, 4, 5, 7 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 2, 1, 5, 4, 8 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 3, 1, 6, 4, 9 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 1, 2, 5, 3, 9 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 3, 2, 5, 1, 7 }, 'X'),
                new Tuple<IList<int>, char?>(new[] { 7, 1, 4, 2, 5, 3 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 7, 4, 1, 5, 2, 6 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 4, 7, 1, 8, 2, 9 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 9, 1, 2, 4, 5, 7 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 9, 2, 1, 5, 4, 8 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 8, 3, 1, 6, 4, 9 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 4, 1, 2, 5, 3, 9 }, 'O'),
                new Tuple<IList<int>, char?>(new[] { 4, 3, 2, 5, 1, 7 }, 'O'),
            };

            TestCaseRunner.Execute(
                testCases,
                testCase =>
                {
                    Console.WriteLine($"Testing:\n{RenderStringGameBoard(testCase.Item1)}");

                    game = gameMgr.CreateNew();

                    // iterate over the moves and test unfinished status
                    for (var moveIdx = 0; moveIdx < testCase.Item1.Count; moveIdx++)
                    {
                        var move = testCase.Item1[moveIdx];
                        var moveSuccess = game.MakeMove(move);
                        Assert.IsTrue(moveSuccess, nameof(moveSuccess));

                        if (moveIdx + 1 != testCase.Item1.Count)
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
                    var player = game.Player1.Mark == testCase.Item2 ? game.Player1 : game.Player2;
                    Assert.AreEqual(player, game.Winner, "game.Winner");
                },
                (testCase, ex) => new AssertFailedException($"Failure \"{ex.Message}\" on test case:\n{RenderStringGameBoard(testCase.Item1)}\n", ex));
        }

        private string RenderStringGameBoard(IEnumerable<int> gameMoves)
        {
            // using 'V' to represent null squares because the test output is not in a fixed-width font
            var filler = 'V';
            var board = new[]
            {
                filler, filler, filler,
                filler, filler, filler,
                filler, filler, filler,
            };
            var currentMark = 'X';
            foreach (var move in gameMoves)
            {
                board[move - 1] = currentMark;

                currentMark = currentMark == 'X' ? 'O' : 'X';
            }

            return $"{board[0]}|{board[1]}|{board[2]}\n" +
                   $"{board[3]}|{board[4]}|{board[5]}\n" +
                   $"{board[6]}|{board[7]}|{board[8]}\n";
        }

        [TestMethod]
        public void Game_MakeMove_after_draw_move_should_update_fields()
        {
            // maybe try a couple more cases but don't think we should determine them all
            var testCases = new[]
            {
                new[] { 1, 4, 2, 5, 6, 3, 7, 8, 9 },
                new[] { 1, 5, 4, 7, 3, 2, 8, 6, 9 },
            };

            TestCaseRunner.Execute(
                testCases,
                moves =>
                {
                    Console.WriteLine($"Testing:\n{RenderStringGameBoard(moves)}");

                    game = gameMgr.CreateNew();

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
                },
                (moves, ex) => new AssertFailedException($"Failure \"{ex.Message}\" on test case:\n{RenderStringGameBoard(moves)}\n", ex));
        }
    }
}
