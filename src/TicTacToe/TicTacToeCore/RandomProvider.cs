using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random rnd;

        public RandomProvider(int? seed = null)
        {
            rnd = seed != null ? new Random(seed.Value) : new Random();
        }

        public int Get(int? maxValue = null)
        {
            return maxValue != null ? rnd.Next(maxValue.Value) : rnd.Next();
        }
    }
}
