using Beowulf.Core.Data.Models;

namespace Beowulf.Core.Models
{
    public class Table(TableModel model, ICellContentRule contentRule)
    {
        private readonly TableModel model = model;
        public TableModel Data => model;

        private readonly ICellContentRule contentRule = contentRule;
        public Cell[] Cells { get; protected set; } = [];

        public Task LoadCells()
        {
            Cells = model.Cells.Select(c => new Cell(this, c, contentRule)).ToArray();
            return Task.CompletedTask;
        }
    }
}
