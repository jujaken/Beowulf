using System.Collections.ObjectModel;

namespace Beowulf.Core.Models
{
    public class Unit(ICellContentRule contentRule, Cell? cell = null) : CellContent(contentRule, cell)
    {
        public ObservableCollection<UnitAttribute> Attributes { get; set; } = [];

        public virtual bool IsAlive => Cell is not null;
        public virtual bool IsDead => Cell is null;
    }
}
