namespace Beowulf.Core.Data.Models
{
    public class CellModel : DataModel
    {
        public double[]? Vector { get; set; }
        public TableModel? Table { get; set; }
        public List<CellModel> Links { get; set; } = [];
    }
}
