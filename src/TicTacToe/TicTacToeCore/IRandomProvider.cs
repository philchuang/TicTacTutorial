using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public interface IRandomProvider
    {
        int Get(int? maxValue = null);
    }
}
