namespace Beowulf.Core
{
    public interface ICellLinkRule
    {
        /// <summary>  должна ли первая клетка иметь ссылку на вторую </summary>
        bool HasLink(double[] cellVector1, double[] cellVector2);
    }
}
