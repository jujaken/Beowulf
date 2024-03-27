namespace Beowulf.Core
{
    public class CornerPosRule(int e = 2) : ICellPosRule
    {
        public int E { get; } = e;

        public double[] Next()
        {
            throw new NotImplementedException();
        }
    }
}
