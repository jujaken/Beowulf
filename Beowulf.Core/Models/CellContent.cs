namespace Beowulf.Core.Models
{
    public class CellContent(ICellContentRule contentRule)
    {
        private readonly ICellContentRule contentRule = contentRule;

        private Cell? cell;
        public Cell? Cell
        {
            get => cell;
            set
            {
                if (cell == value)
                    return;

                contentRule.Remove(cell!, this);

                if (value != null)
                    contentRule.Add(cell!, this);

                cell = value;
            }
        }
    }
}
