namespace Beowulf.Core.Models
{
    public class CellContent(ICellContentRule contentRule, Cell? cell = null)
    {
        private readonly ICellContentRule contentRule = contentRule;

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

                cell = value;
            }
        }
    }
}
