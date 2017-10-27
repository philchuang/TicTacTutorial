namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderStubReturns0 : IRandomProvider
    {
        public int Get(int? maxValue = null)
        {
            return 0;
        }
    }
}
