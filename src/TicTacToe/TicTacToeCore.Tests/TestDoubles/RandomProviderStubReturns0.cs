namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderStubReturns0 : RandomProviderBase
    {
        public override int Get(int? maxValue = null)
        {
            return 0;
        }
    }
}
