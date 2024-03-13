using Beowulf.Core.Data.Models;
using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ICellContentRule
    {
        List<CellContent> Get(double[] vector);
        List<CellContent> Get(CellModel vector);
    }
}
