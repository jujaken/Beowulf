namespace Beowulf.Core.Models
{
    public class CellContent(ICellContentRule contentRule, Cell? cell = null)
    {
        private readonly ICellContentRule contentRule = contentRule;

        public Action<Cell?, Cell?>? CellWasChanged { get; set; }

        private Cell? cell = cell;
        public Cell? Cell
        {
            get => cell;
            set
            {
                if (cell == value)
                    return;

                cell?.Contents.Remove(this);
                value?.Contents.Add(this);

                var oldValue = cell;
                cell = value;

                CellWasChanged?.Invoke(oldValue, cell);
            }
        }

        public void Remove()
        {
            Cell = null;
        }
    }
}
