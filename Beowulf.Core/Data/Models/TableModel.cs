namespace Beowulf.Core.Data.Models
{
    public class TableModel : DataModel
    {
        public int E { get; set; } = 2;
        public List<CellModel> Cells { get; set; } = [];
    }
}
