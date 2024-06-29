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
    public class AddIngridientViewModel : BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;

        public List<Irritant> Irritants { get; set; }
        public IngrridientViewModel Ingredient { get; set; }
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public AddIngridientViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Irritants = context.Irritants.ToList();
                Ingredient = new IngrridientViewModel();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }

        private void saveChanges()
        {
            Ingredient ingridient = Ingredient.ToIngridient();
            using (CosmeticHeathContext context = new())
            {
                if (ingridient.IngredientId == 0)
                {
                    context.Ingredients.Add(ingridient);
                }
                else
                {
                    context.Ingredients.Update(ingridient);
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
