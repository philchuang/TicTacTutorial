using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderSpy : IRandomProvider
    {
        public RandomProviderSpy(IRandomProvider underlyingImpl)
        {
            this.Implementation = underlyingImpl;
            this.GetSpy = new FuncSpy<int?, int>(this.Implementation.Get);
        }

        public IRandomProvider Implementation { get; }

        public FuncSpy<int?, int> GetSpy { get; }

        public int Get(int? maxValue = null)
        {
            return this.GetSpy.Method(maxValue);
        }
    }
}
