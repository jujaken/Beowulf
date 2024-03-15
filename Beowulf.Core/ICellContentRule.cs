using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ICellContentRule
    {
        List<CellContent> Get(double[] subvector);
        double[] Get(List<CellContent> subcontents);
    }
}
