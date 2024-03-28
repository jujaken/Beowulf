using Beowulf.Core.Data.Models;
using Beowulf.Core.Data.Repos;
using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ITableBuilder
    {
        ITableBuilder WithE(int e);
        ITableBuilder WithSize(params int[] sizes);
        ITableBuilder WithTableRepo(IRepo<TableModel> tableRepo);
        ITableBuilder WithCellRepo(IRepo<CellModel> tableRepo);
        ITableBuilder WithCellContentRule(ICellContentRule contentRule, int start, int end);
        Table Build();
    }
}
