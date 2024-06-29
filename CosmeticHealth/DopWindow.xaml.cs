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
using System.Windows.Shapes;

namespace CosmeticHealth
{
    /// <summary>
    /// Логика взаимодействия для DopWindow.xaml
    /// </summary>
    public partial class DopWindow : Window
    {
        public int Num { get; set; }
        public DopWindow()
        {
            InitializeComponent();
        }

        private void AddPrSym(object sender, RoutedEventArgs e)
        {
            Num = 11;
            this.Close();
        }

        private void AddPrType(object sender, RoutedEventArgs e)
        {
            Num = 12;
            this.Close();

        }

        private void AddProdPr(object sender, RoutedEventArgs e)
        {
            Num = 13;
            this.Close();
        }

        private void AddProdShop(object sender, RoutedEventArgs e)
        {
            Num = 14;
            this.Close();
        }

        private void AddPrIng(object sender, RoutedEventArgs e)
        {
            Num = 15;
            this.Close();
        }
    }
}
