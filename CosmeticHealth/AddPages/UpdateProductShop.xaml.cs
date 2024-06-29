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
    /// Логика взаимодействия для UpdateProductShop.xaml
    /// </summary>
    public partial class UpdateProductShop : Page
    {
        public UpdateProductShop(HealthWindowViewModel healthWindowViewModel, int productId)
        {
            InitializeComponent();
            DataContext = new UpdateProductShopViewModel(healthWindowViewModel, productId);
        }
    }
}
