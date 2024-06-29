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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CosmeticHealth.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddProductIngridient.xaml
    /// </summary>
    public partial class AddProductIngridient : Page
    {
        const int num = 15;
        //public ObservableCollection<Product> Products { get; private set; }
        //public ObservableCollection<Ingredient> Ingredients { get; private set; }
        public AddProductIngridient(HealthWindowViewModel healthWindowViewModel, int productIngredientId)
        {
            //Products = new ObservableCollection<Product>(Session.Instance.Context.Products);
            //Ingredients = new ObservableCollection<Ingredient>(Session.Instance.Context.Ingredients);
            InitializeComponent();
            DataContext = new AddProductIngredientViewModel(healthWindowViewModel, productIngredientId);
        }
    }
}
