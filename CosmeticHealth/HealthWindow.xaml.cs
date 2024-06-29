using CosmeticHealth.AddPages;
using CosmeticHealth.Models;
using CosmeticHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CosmeticHealth
{
    /// <summary>
    /// Логика взаимодействия для HealthWindow.xaml
    /// </summary>
    public partial class HealthWindow : Window
    {
        public int N { get; set; }
        public HealthWindow(bool adminOrClient)
        {
            InitializeComponent();
            DataContext = new HealthWindowViewModel(adminOrClient);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
