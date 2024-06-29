using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CosmeticHealth.ViewModels
{
    public class ProductFullPageViewModel : BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Shop> Shops { get; set; }
        public List<ProductShop> ProductShops { get; set; }
        public Product Product { get; set; }
        public List<TypeOfProduct> TypeOfProducts { get; set; }
        public List<TypeOfSkin> TypeOfSkins { get; set; }

        public List<ProductProblem> ProductProblems { get; set; }
        public List<ProductIngredient> ProductIngredients { get; set; }
        public List<Brand> Brands { get; set; }
        public RelayCommand BackTo { get; set; }
        public RelayCommand LinkSearch { get; set; }


        public List<Ingredient> Ingredients { get; set; }

        public List<Problem> Problems { get; set; }

        public string HaveProblems { get; set; }
        public string ListOfIng { get; set; }

        private ProductShop? selectedProductShop;
        public ProductShop? SelectedProductShop
        {
            get => selectedProductShop;
            set
            {
                setAndNotify(ref selectedProductShop, value);
                notifyPropertyChanged(nameof(CanSearchProduct));
            }
        }
        public bool CanSearchProduct => selectedProductShop is not null;
        public ProductFullPageViewModel(HealthWindowViewModel healthWindowViewModel, int productId)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                
                ProductShops = context.ProductShops.ToList();
                Product = context.Products.Where(p => p.ProductId == productId).First();
                TypeOfProducts = context.TypeOfProducts.ToList();
                TypeOfSkins=context.TypeOfSkins.ToList();
                Brands = context.Brands.ToList();
                ProductShops=context.ProductShops.Where(j=>j.Product==productId).Include(p=>p.ShopNavigation).ToList();
                Shops = context.Shops.ToList();

                Ingredients = context.Ingredients.ToList();
                Problems = context.Problems.ToList();
                ProductProblems=context.ProductProblems.Where(p=>p.Product==productId).Include(z=>z.ProblemNavigation).ToList();//
                ProductIngredients=context.ProductIngredients.Where(p=>p.Product==productId).Include(z=>z.IngredientNavigation).OrderByDescending(x=>x.Procent).ToList();
                if (ProductProblems.Count == 0)
                {
                    HaveProblems = "Проблемы не решает";
                }
                else
                {
                    foreach (var problems in ProductProblems)
                    {
                        Problem problem = Problems.Where(z => z.ProblemId == problems.Problem).First();
                        HaveProblems += problem.ProblemName;
                        HaveProblems += ", ";
                    }
                }
                foreach (var ings in ProductIngredients)
                {
                    Ingredient ingredient = Ingredients.Where(z => z.IngredientId == ings.Ingredient).First();
                    ListOfIng += ingredient.NameIngredient;
                    ListOfIng += ", ";
                }
                BackTo = new RelayCommand(_ => backTo());
                LinkSearch = new RelayCommand(_ => links());
            }
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }

        public void links()
        {
            if (CanSearchProduct == false)
            {
                MessageBox.Show("Выберете магазин чтобы перейти по ссылке");
            }
            else
            {
                if (SelectedProductShop.Link != null)
                {
                    Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", SelectedProductShop.Link);
                }
                else
                {
                    MessageBox.Show("К сожалению, ссылки на данный момент нет!!!");
                }
            }
        }
    }
}
