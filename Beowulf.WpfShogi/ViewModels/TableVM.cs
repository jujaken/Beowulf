using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Beowulf.WpfShogi.ViewModels
{
    public partial class TableVM : ObservableObject
    {
        [ObservableProperty] public ObservableCollection<CellVM> cellVMs = [];

        [ObservableProperty] public CellVM? curCellVM;
    }
}
