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
    public class UpdateProductProblemViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;


        public ListCollectionView ProductProblems { get; set; }
        public RelayCommand DeleteProductProblem { get; set; }

        public RelayCommand UpdateProductProblem { get; set; }
        public RelayCommand Back { get; set; }
        public UpdateProductProblemViewModel(HealthWindowViewModel healthWindowViewModel, int productId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProductProblems = new ListCollectionView(context.ProductProblems.Include(z => z.ProductNavigation).Include(x => x.ProblemNavigation).Where(d => d.Product == productId).ToList());
                Back = new RelayCommand(_ => backTo());
                DeleteProductProblem = new RelayCommand(_ => delete(SelectedProductProblem));
                UpdateProductProblem = new RelayCommand(_ => nagToUpdate(SelectedProductProblem?.ProductProblemId ?? 0));
            }
        }


        private ProductProblem? selectedProductProblem;
        public ProductProblem? SelectedProductProblem
        {
            get => selectedProductProblem;
            set
            {
                setAndNotify(ref selectedProductProblem, value);
                notifyPropertyChanged(nameof(CanEditProduct));
            }
        }
        public bool CanEditProduct => selectedProductProblem != null;


        public void delete(ProductProblem productProblem)
        {
            using (CosmeticHeathContext context = new())
            {
                try
                {
                    context.ProductProblems.Remove(productProblem);
                    context.SaveChanges();
                    ProductProblems.Remove(productProblem);
                    MessageBox.Show("Продукт_Проблема удален", "Удаление успешно", MessageBoxButton.OK, MessageBoxImage.Information);
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
            healthWindowViewModel.NavigatetoUpdateProductProblem(productProblemId);
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
