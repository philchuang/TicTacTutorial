using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.PhilChuang.Apps.TicTacToe.Tests
{
    public static class TestCaseRunner
    {
        /// <summary>
        /// Executes all given test cases against the given test and reports on the total number of passes and failures.
        /// </summary>
        /// <typeparam name="TTestCase">the test case type</typeparam>
        /// <param name="testCases">the test cases</param>
        /// <param name="test">the test to execute</param>
        public static void Execute<TTestCase>(IEnumerable<TTestCase> testCases, Action<TTestCase> test)
        {
            Execute(testCases, test, (testCase, ex) => ex);
        }

        /// <summary>
        /// Executes all given test cases against the given test and reports on the total number of passes and failures.
        /// </summary>
        /// <typeparam name="TTestCase">the test case type</typeparam>
        /// <param name="testCases">the test cases</param>
        /// <param name="test">the test to execute</param>
        /// <param name="exceptionWrapper">the function to wrap exceptions</param>
        public static void Execute<TTestCase>(IEnumerable<TTestCase> testCases, Action<TTestCase> test, Func<TTestCase, Exception, Exception> exceptionWrapper)
        {
            var successes = 0;
            var failures = new List<Exception>();

            foreach (var testCase in testCases)
            {
                try
                {
                    test(testCase);
                    successes++;
                }
                catch (Exception ex)
                {
                    failures.Add(exceptionWrapper(testCase, ex));
                }
            }

            Assert.IsFalse(failures.Any(), $"{successes}/{successes + failures.Count} test casses passed.\nThese test cases failed:\n{string.Join("\n", failures.Select(ex => ex.Message))}");
        }
    }
}
