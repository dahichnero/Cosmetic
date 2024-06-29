using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticHealth.ViewModels
{
    public class ProductViewModel : BaseViewModel, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Description" && string.IsNullOrWhiteSpace(Description))
                {
                    return "Описание не может быть пустым!";
                }
                if (columnName == "HowUse" && string.IsNullOrWhiteSpace(HowUse))
                {
                    return "Способ применения не может быть пустым!";
                }
                if (columnName == "Image" && string.IsNullOrWhiteSpace(Image))
                {
                    return "Ссылка на изображение не может быть пустой!";
                }
                if (columnName == "ProductName" && string.IsNullOrWhiteSpace(ProductName))
                {
                    return "Название товара не может быть пустым!";
                }
                if (columnName == "ProductName" && ProductName.Length >= 100)
                {
                    return "Название товара не может содержать более 100 знаков!";
                }
                if (columnName == "Type" && Type == null)
                {
                    return "Выберите вид продукта!!!";
                }
                if (columnName == "Brand" && Brand == null)
                {
                    return "Выберите бренд!!!";
                }
                if (columnName == "TypeOfSkin" && TypeOfSkin == null)
                {
                    return "Выберите тип кожи!!!";
                }
                if (columnName == "Irritant" && Irritant == null)
                {
                    return "Выберите есть ли раздражители или нет!!!";
                }
                return null!;
            }
        }
        public string Error => null!;

        public ProductViewModel() { }

        public ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Brand = product.BrandNavigation;
            Type = product.TypeNavigation;
            Description = product.Description;
            HowUse = product.HowUse;
            TypeOfSkin = product.TypeOfSkinNavigation;
            Image = product.Image;
            Irritant = product.IrritantNavigation;
        }

        public Product ToProduct() => new Product
        {
            ProductId = ProductId,
            ProductName = ProductName,
            Brand = Brand!.BrandId,
            Type = Type!.TypeOfProductId,
            Description = Description,
            HowUse = HowUse,
            TypeOfSkin = TypeOfSkin!.TypeOfSkinId,
            Image = Image,
            Irritant=Irritant!.IrritantId,
        };

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public Brand? Brand { get; set; }

        public TypeOfProduct? Type { get; set; }

        public string? Description { get; set; }

        public string HowUse { get; set; } = null!;

        public TypeOfSkin? TypeOfSkin { get; set; }

        public string? Image { get; set; }
        public Irritant? Irritant { get; set; }
    }
}
