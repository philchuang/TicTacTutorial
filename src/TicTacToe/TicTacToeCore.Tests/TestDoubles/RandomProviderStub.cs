using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderStub : RandomProviderBase
    {
        public Func<int?, int> GetOverride { get; set; }

        public override int Get(int? maxValue = null)
        {
            return this.GetOverride(maxValue);
        }
    }
}
