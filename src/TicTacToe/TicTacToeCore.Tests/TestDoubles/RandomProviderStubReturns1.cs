namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderStubReturns1 : RandomProviderBase
    {
        public override int Get(int? maxValue = null)
        {
            return 1;
        }
    }
}
