using CosmeticHealth.AddPages;
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
    /// Логика взаимодействия для WhatAddWindow.xaml
    /// </summary>
    public partial class WhatAddWindow : Window
    {
        public WhatAddWindow()
        {
            InitializeComponent();
        }
        public int NumPage { get; set; }
        private void DLC(object sender, RoutedEventArgs e)
        {
            DopWindow dopWindow = new DopWindow();
            dopWindow.ShowDialog();
            if (dopWindow.Num != 0)
            {
                NumPage=dopWindow.Num;
                this.Close();
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            NumPage = 5;
            this.Close();
        }

        private void AddProblem(object sender, RoutedEventArgs e)
        {
            NumPage = 6;
            this.Close();
        }

        private void AddBrand(object sender, RoutedEventArgs e)
        {
            NumPage = 7;
            this.Close();
        }

        private void AddSymptom(object sender, RoutedEventArgs e)
        {
            NumPage = 8;
            this.Close();
        }

        private void AddIngridient(object sender, RoutedEventArgs e)
        {
            NumPage= 9;
            this.Close();
        }

        private void AddShop(object sender, RoutedEventArgs e)
        {
            NumPage = 10;
            this.Close();
        }
    }
}
