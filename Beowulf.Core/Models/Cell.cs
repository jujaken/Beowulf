using Beowulf.Core.Data.Models;
using Beowulf.Core.Data.Repos;

namespace Beowulf.Core.Models
{
    public class Cell(CellModel model, IRepo<CellModel> repo, ICellContentRule contentRule)
    {
        private readonly CellModel model = model;
        private readonly IRepo<CellModel> repo = repo;
        private readonly ICellContentRule contentRule = contentRule;

        public CellModel Data = model;
        public List<CellContent> Contents { get; } = contentRule.Get(model);
    }
}
