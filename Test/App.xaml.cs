using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Test.Model;
using Test.ViewModel;

namespace Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var history = new ObservableCollection<Equation>();
            var model = new MathematicalModel(history);
            var mathematicalViewModel = new MathematicalViewModel(model, history);
            var mainWindow = new MainWindow { DataContext = mathematicalViewModel };

            mainWindow.Show();
        }
    }
}
