using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ICellContentRule
    {
        List<CellContent> Get(double[] vector);
        double[] Get(List<CellContent> vector);
    }
}
