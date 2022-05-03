using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Logging_Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MainWindow MainW = new MainWindow();
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainW.Show();
        }
    }
}
