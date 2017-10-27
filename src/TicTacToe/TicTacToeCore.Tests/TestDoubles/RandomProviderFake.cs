using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderFake : IRandomProvider
    {
        private int lastValue = 0;

        public int Get(int? maxValue = null)
        {
            if (lastValue == 1) lastValue = 0;
            return lastValue++;
        }
    }
}
