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
    public class UpdateProductIngredientViewModel: BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;


        public ListCollectionView ProductIngredients { get; set; }
        public RelayCommand DeleteProductIngredient { get; set; }

        public RelayCommand UpdateProductIngredient { get; set; }
        public RelayCommand Back { get; set; }
        public UpdateProductIngredientViewModel(HealthWindowViewModel healthWindowViewModel, int productId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProductIngredients = new ListCollectionView(context.ProductIngredients.Include(z => z.ProductNavigation).Include(x => x.IngredientNavigation).Where(d => d.Product == productId).ToList());
                Back = new RelayCommand(_ => backTo());
                DeleteProductIngredient = new RelayCommand(_ => delete(SelectedProductIngredient));
                UpdateProductIngredient = new RelayCommand(_ => nagToUpdate(SelectedProductIngredient?.ProductIngredientId ?? 0));
            }
        }


        private ProductIngredient? selectedProductIngredient;
        public ProductIngredient? SelectedProductIngredient
        {
            get => selectedProductIngredient;
            set
            {
                setAndNotify(ref selectedProductIngredient, value);
                notifyPropertyChanged(nameof(CanEditProduct));
            }
        }
        public bool CanEditProduct => selectedProductIngredient != null;


        public void delete(ProductIngredient productIngredient)
        {
            using (CosmeticHeathContext context = new())
            {
                try
                {
                    context.ProductIngredients.Remove(productIngredient);
                    context.SaveChanges();
                    ProductIngredients.Remove(productIngredient);
                    MessageBox.Show("Продукт_Ингредиент удален", "Удаление успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void nagToUpdate(int productProblemId)
        {
            healthWindowViewModel.NavigatetoUpdateProductIngredient(productProblemId);
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
