using CosmeticHealth.ViewModels;
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

namespace CosmeticHealth
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

        private void sighin(object sender, RoutedEventArgs e)
        {
            var wnd = (ClientOrCons.IsChecked, login.Text, pass.Text) switch
            {
                (false, "admin", "adminCosmetic") => new HealthWindow(true), // администратор
                (true, _, _) => new HealthWindow(false), // киоск
                _ => null
            };

            if (wnd is null)
            {
                MessageBox.Show("Не верный логин или пароль", "Вход не выполнен", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            wnd.Show();
            this.Close();
        }

        
    }
}
