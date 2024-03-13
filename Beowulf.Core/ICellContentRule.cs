using Beowulf.Core.Data.Models;
using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ICellContentRule
    {
        double[] Add(double[] vector, CellContent cellContents);
        double[] Add(CellModel cell, CellContent cellContents);
        double[] Add(Cell cell, CellContent cellContents);

        double[] Remove(double[] vector, CellContent cellContents);
        double[] Remove(CellModel cell, CellContent cellContents);
        double[] Remove(Cell cell, CellContent cellContents);

        List<CellContent> Get(double[] vector);
        List<CellContent> Get(CellModel cell);
        List<CellContent> Get(Cell cell);
    }
}
