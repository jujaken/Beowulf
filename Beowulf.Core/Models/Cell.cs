using Beowulf.Core.Data.Models;
using Beowulf.Core.Data.Repos;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Beowulf.Core.Models
{
    public class Cell
    {
        public Table Table { get; protected set; }

        protected CellModel Data { get; }

        private readonly IRepo<CellModel> repo;
        private readonly ICellContentRule contentRule;

        public ObservableCollection<CellContent> Contents { get; set; }

        public Cell(Table table, CellModel data, IRepo<CellModel> repo, ICellContentRule contentRule)
        {
            Table = table;
            Data = data;

            this.repo = repo;
            this.contentRule = contentRule;

            Contents = new(contentRule.Get(data.Vector ?? []));
            Contents.CollectionChanged += ContentsChanged;
        }

        private void ContentsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Data.Vector = contentRule.Get(Contents.ToList());
            repo.Update(Data);
        }
    }
}
