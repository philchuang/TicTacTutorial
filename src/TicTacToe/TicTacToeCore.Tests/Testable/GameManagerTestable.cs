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
        public Func<int?, int> RandomProviderGetOverride
        {
            get { return ((RandomProviderStub) this.RandomProvider).GetOverride; }
            set { ((RandomProviderStub) this.RandomProvider).GetOverride = value; }
        }

        protected override RandomProviderBase MakeRandomProvider()
        {
            return new RandomProviderStub();
        }
    }
}
