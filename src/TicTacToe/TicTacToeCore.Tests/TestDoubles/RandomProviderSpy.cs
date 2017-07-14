using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderSpy : RandomProviderBase
    {
        public RandomProviderSpy(RandomProviderBase underlyingImpl)
        {
            this.Implementation = underlyingImpl;
            this.GetSpy = new FuncSpy<int?, int>(this.Implementation.Get);
        }

        public RandomProviderBase Implementation { get; }

        public FuncSpy<int?, int> GetSpy { get; }

        public override int Get(int? maxValue = null)
        {
            return this.GetSpy.Method(maxValue);
        }
    }
}
