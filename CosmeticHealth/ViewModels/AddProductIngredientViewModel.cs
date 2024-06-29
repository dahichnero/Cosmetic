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
    public class AddProductIngredientViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public ProductIngredientViewModel ProductIngredient { get; set; }
        public List<Product> Products { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<ProductIngredient> ProductIngredients { get; set; }
        public AddProductIngredientViewModel(HealthWindowViewModel healthWindowViewModel, int productIngredientId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProductIngredients = context.ProductIngredients.ToList();
                var found = context.ProductIngredients.Include(z => z.ProductNavigation).Include(x => x.IngredientNavigation).FirstOrDefault(c => c.ProductIngredientId == productIngredientId);
                if (found is null)
                {
                    ProductIngredient = new ProductIngredientViewModel();
                }
                else
                {
                    ProductIngredient = new ProductIngredientViewModel(found);
                }
                //ProductIngredient = new ProductIngredientViewModel();
                Products = context.Products.ToList();
                Ingredients = context.Ingredients.OrderBy(z=>z.NameIngredient).ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        private void saveChanges()
        {
            ProductIngredient product = ProductIngredient.ToProdIng();
            double sum = 0;
            int pro = ProductIngredient.Product.Irritant;
            int ing = ProductIngredient.Ingredient.Irritant;
            using (CosmeticHeathContext context = new())
            {
                sum = ProductIngredients.Where(p=>p.Product==product.Product).Sum(x=>x.Procent);
                if (IsNormal(pro,ing) && sum + product.Procent <= 100)
                {
                    if (product.ProductIngredientId == 0)
                    {
                        context.ProductIngredients.Add(product);
                    }
                    else
                    {
                        context.ProductIngredients.Update(product);
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
                else
                {
                    MessageBox.Show("Ошибка", "Error");
                }
            }

        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
        private bool IsNormal(int first, int second)
        {
            if( (first==1 && second==1) || (first==2 && second==2) || (first==2 && second == 1))
            {
                return true;
            }
            return false;
        }
    }
}
