using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfTreeViewsAndValueConverters.Directory.ViewModels;

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

            var viewModel = new DirectoryStructureViewModel();
            DataContext = viewModel;
        }
    }
}
