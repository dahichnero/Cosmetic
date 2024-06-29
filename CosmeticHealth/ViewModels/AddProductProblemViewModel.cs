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
    public class AddProductProblemViewModel: BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Product> Products { get; set; }
        public List<Problem> Problems { get; set; }
        public ProductProblemViewModel ProductProblem { get; set; }
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public AddProductProblemViewModel(HealthWindowViewModel healthWindowViewModel, int productProblemId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                var found=context.ProductProblems.Include(z=>z.ProductNavigation).Include(x=>x.ProblemNavigation).FirstOrDefault(s=>s.ProductProblemId==productProblemId);
                if (found is null)
                {
                    ProductProblem = new ProductProblemViewModel();
                }
                else
                {
                    ProductProblem = new ProductProblemViewModel(found);
                }
                Products = context.Products.ToList();
                Problems = context.Problems.ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }

        private void saveChanges()
        {
            ProductProblem prodProb = ProductProblem.ToProdProb();
            using (CosmeticHeathContext context = new())
            {
                if (prodProb.ProductProblemId == 0)
                {
                    context.ProductProblems.Add(prodProb);
                }
                else
                {
                    context.ProductProblems.Update(prodProb);
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
