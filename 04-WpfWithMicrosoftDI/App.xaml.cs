using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

using Microsoft.Extensions.DependencyInjection;

namespace WpfDITestbed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainWindow { DataContext = IoC.IoCContainer.Provider.GetService<IMainViewModel>() };
            MainWindow.Show();
        }
    }
}
