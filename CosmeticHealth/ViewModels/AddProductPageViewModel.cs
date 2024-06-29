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
    public class AddProductPageViewModel :BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Brand> Brands { get; set; }
        public List<TypeOfSkin> TypeOfSkins { get; set; }
        public List<TypeOfProduct> TypeOfProducts { get; set; }
        public List<Irritant> Irritants { get; set; }
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public ProductViewModel Product { get; set; }
        public AddProductPageViewModel(HealthWindowViewModel healthWindowViewModel, int idProduct)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                var found=context.Products.Include(z=>z.BrandNavigation).Include(x=>x.TypeOfSkinNavigation).Include(c=>c.TypeNavigation).Include(c=>c.IrritantNavigation).FirstOrDefault(p=>p.ProductId==idProduct);
                if (found is null)
                {
                    Product = new ProductViewModel();
                }
                else
                {
                    Product=new ProductViewModel(found);
                }
                //Product = new ProductViewModel();
                Brands = context.Brands.ToList();
                TypeOfSkins = context.TypeOfSkins.ToList();
                TypeOfProducts = context.TypeOfProducts.ToList();
                Irritants=context.Irritants.ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }

        private void saveChanges()
        {
            Product product = Product.ToProduct();
            using (CosmeticHeathContext context = new())
            {
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
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
