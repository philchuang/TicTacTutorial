namespace Com.PhilChuang.Apps.TicTacToe.Tests.TestDoubles
{
    public class RandomProviderDummy : RandomProviderBase
    {
        public override int Get(int? maxValue = null)
        {
            return default(int);
        }
    }
}
