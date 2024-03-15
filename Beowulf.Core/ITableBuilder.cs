using Beowulf.Core.Models;

namespace Beowulf.Core
{
    public interface ITableBuilder
    {
        ITableBuilder WithE(int e);
        ITableBuilder WithCellContentRule(ICellContentRule contentRule, int start, int end);
        ITableBuilder WithCellContentRule(ICellPosRule posRule);
        ITableBuilder WithCellContentRule(ICellLinkRule linkRule);
        Table Build();
    }
}
