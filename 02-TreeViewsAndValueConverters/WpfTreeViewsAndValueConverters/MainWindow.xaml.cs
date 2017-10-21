using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeViewsAndValueConverters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PopulateTreeItem(TreeViewItem treeItem)
        {
            string path = (string)treeItem.Tag;

            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    var directoryItem = new TreeViewItem
                    {
                        Header = Path.GetFileName(directory),
                        Tag = directory
                    };

                    directoryItem.Items.Add(null);

                    directoryItem.Expanded += LogicalDriveItem_Expanded;

                    treeItem.Items.Add(directoryItem);
                }
            }
            catch { }

            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    var fileItem = new TreeViewItem
                    {
                        Header = Path.GetFileName(file),
                        Tag = file
                    };

                    treeItem.Items.Add(fileItem);
                }

                treeItem.Expanded += LogicalDriveItem_Expanded;
            }
            catch { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] logicalDrives = Directory.GetLogicalDrives();
            foreach (string logicalDrive in logicalDrives)
            {
                var logicalDriveItem = new TreeViewItem
                {
                    Header = logicalDrive,
                    Tag = logicalDrive
                };

                PopulateTreeItem(logicalDriveItem);

                FolderView.Items.Add(logicalDriveItem);
            }
        }

        private void LogicalDriveItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            string path = (string)item.Tag;

            PopulateTreeItem(item);
        }
    }
}
