using Beowulf.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Beowulf.Core.Data
{
    public class BeowulfDbContext : DbContext
    {
        public DbSet<CellModel> Cells { get; set; }
        public DbSet<TableModel> Tables { get; set; }
    }
}
