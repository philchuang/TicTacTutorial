using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    [TestClass]
    public class BoardTests
    {
        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Board_indexer_get_with_invalid_square_number_should_throw_exception()
        {
            var mark = board[10];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Board_indexer_set_with_invalid_square_number_should_throw_exception()
        {
            board[10] = 'X';
        }

        [TestMethod]
        public void Board_indexer_for_square_1_should_set_square_1()
        {
            var oldValue = board[1];
            board[1] = 'X';
            var newValue = board[1];

            Assert.IsNull(oldValue, $"{nameof(oldValue)} != null");
            Assert.AreEqual('X', newValue, nameof(newValue));
        }

        [TestMethod]
        public void Board_indexer_for_square_2_should_set_square_2()
        {
            var oldValue = board[2];
            board[2] = 'X';
            var newValue = board[2];

            Assert.IsNull(oldValue, $"{nameof(oldValue)} != null");
            Assert.AreEqual('X', newValue, nameof(newValue));
        }

        [TestMethod]
        public void Board_indexer_for_square_3_should_set_square_3()
        {
            var oldValue = board[3];
            board[3] = 'X';
            var newValue = board[3];

            Assert.IsNull(oldValue, $"{nameof(oldValue)} != null");
            Assert.AreEqual('X', newValue, nameof(newValue));
        }

    }
}
