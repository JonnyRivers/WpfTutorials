using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasics
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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.DescriptionTextBox.Text);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            DescriptionTextBox.Text = String.Empty;

            WeldCheckBox.IsChecked = false;
            AssemblyCheckBox.IsChecked = false;
            PlasmaCheckBox.IsChecked = false;
            LaserCheckBox.IsChecked = false;
            PurchaseCheckBox.IsChecked = false;
            LatheCheckBox.IsChecked = false;
            DrillCheckBox.IsChecked = false;
            FoldCheckBox.IsChecked = false;
            RollCheckBox.IsChecked = false;
            SawCheckBox.IsChecked = false;
        }

        private void WorkCenterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            LengthTextBox.Text += checkBox.Content;
        }

        private void FinishComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteTextBox == null)
                return;

            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem comboBoxSelectedItem = (ComboBoxItem)comboBox.SelectedValue;
            NoteTextBox.Text = comboBoxSelectedItem.Content.ToString();
        }
    }
}
