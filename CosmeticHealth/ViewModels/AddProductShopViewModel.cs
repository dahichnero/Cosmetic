using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CosmeticHealth.ViewModels
{
    public class AddProductShopViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Product> Products { get; set; }
        public List<Shop> Shops { get; set; }
        public ProductShopViewModel ProductShop { get; set; }
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public AddProductShopViewModel(HealthWindowViewModel healthWindowViewModel, int productShopId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                var found=context.ProductShops.Include(z=>z.ProductNavigation).Include(x=>x.ShopNavigation).FirstOrDefault(s=>s.ProductShopId==productShopId);
                if (found is null)
                {
                    ProductShop = new ProductShopViewModel();
                }
                else
                {
                    ProductShop = new ProductShopViewModel(found);
                }
                Products = context.Products.ToList();
                Shops = context.Shops.ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        private void saveChanges()
        {
            ProductShop prodShop = ProductShop.ToProdShop();
            using (CosmeticHeathContext context = new())
            {
                if (prodShop.ProductShopId == 0)
                {
                    context.ProductShops.Add(prodShop);
                }
                else
                {
                    context.ProductShops.Update(prodShop);
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
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
