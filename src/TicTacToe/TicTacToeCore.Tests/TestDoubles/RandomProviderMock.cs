using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderMock : IRandomProvider
    {
        public Func<int?, int> GetOverride { get; set; }

        public int Get(int? maxValue = null)
        {
            return this.GetOverride(maxValue);
        }
    }
}
