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
    public class AddBrandViewModel: BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;

        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public BrandViewModel Brand { get; set; }
        public AddBrandViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Brand = new BrandViewModel();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        private void saveChanges()
        {
            Brand brand = Brand.ToBrand();
            using (CosmeticHeathContext context = new())
            {
                if (brand.BrandId == 0)
                {
                    context.Brands.Add(brand);
                }
                else
                {
                    context.Brands.Update(brand);
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
