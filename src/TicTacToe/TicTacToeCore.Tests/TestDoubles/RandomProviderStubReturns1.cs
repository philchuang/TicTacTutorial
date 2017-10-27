namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderStubReturns1 : IRandomProvider
    {
        public int Get(int? maxValue = null)
        {
            return 1;
        }
    }
}
