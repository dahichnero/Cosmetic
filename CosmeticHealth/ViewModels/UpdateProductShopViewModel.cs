using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CosmeticHealth.ViewModels
{
    public class UpdateProductShopViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        

        public ListCollectionView ProductShops { get; set; }
        public RelayCommand DeleteProductShop { get; set; }

        public RelayCommand UpdateProductShop { get; set; }
        public RelayCommand Back { get; set; }
        public UpdateProductShopViewModel(HealthWindowViewModel healthWindowViewModel, int productId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProductShops = new ListCollectionView(context.ProductShops.Include(z => z.ProductNavigation).Include(x => x.ShopNavigation).Where(d => d.Product == productId).ToList());
                Back = new RelayCommand(_ => backTo());
                DeleteProductShop = new RelayCommand(_ => delete(SelectedProductShop));
                UpdateProductShop = new RelayCommand(_ => nagToUpdate(SelectedProductShop?.ProductShopId ?? 0));
            }
        }


        private ProductShop? selectedProductShop;
        public ProductShop? SelectedProductShop
        {
            get => selectedProductShop;
            set
            {
                setAndNotify(ref selectedProductShop, value);
                notifyPropertyChanged(nameof(CanEditProduct));
            }
        }
        public bool CanEditProduct => selectedProductShop != null;


        public void delete(ProductShop productShop)
        {
            using (CosmeticHeathContext context = new())
            {
                try
                {
                    context.ProductShops.Remove(productShop);
                    context.SaveChanges();
                    ProductShops.Remove(productShop);
                    MessageBox.Show("Продукт_Магазин удален", "Удаление успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void nagToUpdate(int productShopId)
        {
            healthWindowViewModel.NavigatetoUpdateProductShop(productShopId);
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
