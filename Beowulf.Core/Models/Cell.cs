using Beowulf.Core.Data.Models;
using Beowulf.Core.Data.Repos;

namespace Beowulf.Core.Models
{
    public class Cell(CellModel model, ICellContentRule contentRule)
    {
        private readonly CellModel model = model;
        private readonly ICellContentRule contentRule = contentRule;

        public CellModel Data = model;
        public List<CellContent> Contents { get; } = contentRule.Get(model);
    }
}
