using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class FuncSpy<TParam1, TResult>
    {
        public Func<int, TParam1, TResult> OnCall { get; } = (callNum, param1) => default(TResult);

        public IList<Tuple<TParam1, TResult>> Calls { get; } = new List<Tuple<TParam1, TResult>>();

        public FuncSpy(Func<TParam1, TResult> onCallFunc = null)
        {
            if (onCallFunc != null) this.OnCall = (callNum, param1) => onCallFunc(param1);
        }

        public FuncSpy(Func<int, TParam1, TResult> onCallFunc = null)
        {
            if (onCallFunc != null) this.OnCall = onCallFunc;
        }

        public TResult Method(TParam1 param1)
        {
            var result = this.OnCall(this.Calls.Count, param1);
            this.Calls.Add(new Tuple<TParam1, TResult>(param1, result));
            return result;
        }
    }
}
