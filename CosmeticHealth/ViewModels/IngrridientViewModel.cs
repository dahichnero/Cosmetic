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
    public class IngrridientViewModel : BaseViewModel, IDataErrorInfo
    {
        public IngrridientViewModel()
        {
        }

        public IngrridientViewModel(Ingredient ingredient)
        {
            IngredientId=ingredient.IngredientId;
            NameIngredient=ingredient.NameIngredient;
            Description=ingredient.Description;
            Irritant=ingredient.IrritantNavigation;
        }

        public Ingredient ToIngridient() => new Ingredient
        {
            IngredientId = IngredientId,
            NameIngredient=NameIngredient,
            Description=Description,
            Irritant=Irritant!.IrritantId
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "NameIngredient" && string.IsNullOrWhiteSpace(NameIngredient))
                {
                    return "Название ингредиента не может быть пустым!";
                }
                if (columnName == "NameIngredient" && NameIngredient.Length >= 200)
                {
                    return "Название ингредиента не может содержать более 200 знаков!";
                }
                if (columnName == "Description" && string.IsNullOrWhiteSpace(Description))
                {
                    return "Описание не может быть пустым!";
                }
                if (columnName == "Irritant" && Irritant == null)
                {
                    return "Выберите раздражитель или нет";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int IngredientId { get; set; }

        public string NameIngredient { get; set; } = null!;

        public string? Description { get; set; }

        public Irritant? Irritant { get; set; }
    }
}
