namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderDummy : IRandomProvider
    {
        public int Get(int? maxValue = null)
        {
            return default(int);
        }
    }
}
