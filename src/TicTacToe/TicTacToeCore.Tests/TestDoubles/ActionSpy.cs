using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class ActionSpy<TParam1>
    {
        public Action<int, TParam1> OnCall { get; } = (callNum, param1) => { };

        public IList<TParam1> Calls { get; } = new List<TParam1>();

        public ActionSpy(Action<TParam1> onCallAction = null)
        {
            if (onCallAction != null) this.OnCall = (callNum, param1) => onCallAction(param1);
        }

        public ActionSpy(Action<int, TParam1> onCallAction = null)
        {
            if (onCallAction != null) this.OnCall = onCallAction;
        }

        public void Method(TParam1 param1)
        {
            this.Calls.Add(param1);
            this.OnCall(this.Calls.Count, param1);
        }
    }
}
