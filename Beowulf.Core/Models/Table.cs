using Beowulf.Core.Data.Models;
using Beowulf.Core.Data.Repos;
using System.Collections.ObjectModel;

namespace Beowulf.Core.Models
{
    public class Table
    {
        protected TableModel Data { get; }

        private readonly IRepo<TableModel> repo;
        private readonly IRepo<CellModel> cellRepo;

        private readonly ICellContentRule contentRule;
        public ObservableCollection<Cell> Cells { get; protected set; } = [];

        public Table(TableModel model, IRepo<TableModel> repo, IRepo<CellModel> cellRepo, ICellContentRule contentRule)
        {
            Data = model;

            this.repo = repo;
            this.cellRepo = cellRepo;
            this.contentRule = contentRule;

            Cells = new(Data.Cells.Select(c => new Cell(this, c, cellRepo, contentRule)));
        }
    }
}
