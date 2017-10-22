using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTreeViewsAndValueConverters.Directory.Data;

namespace WpfTreeViewsAndValueConverters.Directory.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        private ObservableCollection<DirectoryItemViewModel> _items;

        public ObservableCollection<DirectoryItemViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items == value)
                    return;

                _items = value;

                RaisePropertyChanged(nameof(Items));
            }
        }

        public DirectoryStructureViewModel()
        {
            List<DirectoryItem> items = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(items.Select(
                item => new DirectoryItemViewModel(item.FullPath, item.Type)));
        }
    }
}
