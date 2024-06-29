using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CosmeticHealth.ViewModels
{
    public class ProductIngredientViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProductIngredientViewModel()
        {
        }

        public ProductIngredientViewModel(ProductIngredient productIngredient)
        {
            ProductIngredientId=productIngredient.ProductIngredientId;
            Product = productIngredient.ProductNavigation;
            Ingredient=productIngredient.IngredientNavigation;
            Procent = productIngredient.Procent;
        }

        public ProductIngredient ToProdIng() => new ProductIngredient
        {
            ProductIngredientId=ProductIngredientId,
            Product=Product!.ProductId,
            Ingredient=Ingredient!.IngredientId,
            Procent=Procent,
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Procent" && Procent>100)
                {
                    return "Процент содержания не должен содержать больше 1";
                }
                if (columnName == "Procent" && Procent<=0)
                {
                    return "Процент содержания не должен меньше или равен нулю";
                }
                if (columnName == "Product" && Product == null)
                {
                    return "Выберите продукт!!!";
                }
                if (columnName == "Ingredient" && Ingredient == null)
                {
                    return "Выберите ингредиент!!!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ProductIngredientId { get; set; }

        public Product? Product { get; set; }

        public Ingredient? Ingredient { get; set; }

        public double Procent { get; set; }
    }
}
