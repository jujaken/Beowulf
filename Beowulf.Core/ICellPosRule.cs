namespace Beowulf.Core
{
    public interface ICellPosRule
    {
        int E { get; }
        double[] Next();
    }
}
