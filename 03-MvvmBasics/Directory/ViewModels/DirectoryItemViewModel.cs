using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewsAndValueConverters.Directory.ViewModels
{
    using Directory.Data;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class DirectoryItemViewModel : BaseViewModel
    {
        private string _fullPath;
        private ObservableCollection<DirectoryItemViewModel> _children;

        public string FullPath
        {
            get { return _fullPath; }
            set
            {
                if (_fullPath == value)
                    return;

                _fullPath = value;

                RaisePropertyChanged(nameof(FullPath));
            }
        }

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);

            FullPath = fullPath;
            Type = type;

            ClearChildren();
        }

        public DirectoryItemType Type { get; set; }

        public string Name
        {
            get
            {
                if (Type == DirectoryItemType.Drive)
                    return FullPath;

                return System.IO.Path.GetFileName(FullPath);
            }
        }

        public ObservableCollection<DirectoryItemViewModel> Children
        {
            get { return _children; }
            set
            {
                if (_children == value)
                    return;

                _children = value;

                RaisePropertyChanged(nameof(Children));
            }
        }

        public bool CanExpand
        {
            get
            {
                return Type != DirectoryItemType.File;
            }
        }

        public bool IsExpanded
        {
            get
            {
                if (Children == null)
                    return false;

                return Children.Any(f => f != null);
            }
            set
            {
                if (value == true)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }

                RaisePropertyChanged(nameof(IsExpanded));
            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;

            List<DirectoryItem> directoryItems = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(
                directoryItems.Select(
                    content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
    }
}
