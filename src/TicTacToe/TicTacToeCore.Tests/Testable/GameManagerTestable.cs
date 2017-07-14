using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.Testable
{
    public class GameManagerTestable : GameManager
    {
        // NOTE this could also just be a plain RandomProviderBase property instead of a lambda, but I like lambdas because it has more flexibility
        public Func<RandomProviderBase> MakeRandomProviderOverride { get; set; }

        protected override RandomProviderBase MakeRandomProvider()
        {
            return (this.MakeRandomProviderOverride ?? base.MakeRandomProvider)();
        }
    }
}
