using CosmeticHealth.Models;
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

namespace CosmeticHealth.AddPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateProductIngredient.xaml
    /// </summary>
    public partial class UpdateProductIngredient : Page
    {
        public UpdateProductIngredient(HealthWindowViewModel healthWindowViewModel, int productIngredientId)
        {
            InitializeComponent();
            DataContext = new UpdateProductIngredientViewModel(healthWindowViewModel, productIngredientId);
        }
    }
}
