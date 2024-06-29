using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CosmeticHealth.ViewModels
{
    public class AddShopViewModel :BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public RelayCommand Back { get; set; }
        public RelayCommand Accept { get; set; }
        public ShopViewModel Shop { get; set; }
        public AddShopViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Shop = new ShopViewModel();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }

        private void saveChanges()
        {
            Shop shop = Shop.ToShop();
            using (CosmeticHeathContext context = new())
            {
                if (shop.ShopId == 0)
                {
                    context.Shops.Add(shop);
                }
                else
                {
                    context.Shops.Update(shop);
                }
                try
                {
                    context.SaveChanges();
                    backTo();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Error!");
                }
            }

        }
    }
}
