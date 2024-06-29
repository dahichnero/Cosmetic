using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CosmeticHealth.ViewModels
{
    public class ProductShopViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProductShopViewModel()
        {
        }

        public ProductShopViewModel(ProductShop productShop)
        {
            ProductShopId=productShop.ProductShopId;
            Product=productShop.ProductNavigation;
            Shop=productShop.ShopNavigation;
            Link=productShop.Link;
        }

        public ProductShop ToProdShop() => new ProductShop
        {
            ProductShopId=ProductShopId,
            Product=Product!.ProductId,
            Shop=Shop!.ShopId,
            Link=Link,
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Link" && string.IsNullOrWhiteSpace(Link))
                {
                    return "Ссылка не может быть пустой!";
                }
                if (columnName == "Product" && Product == null)
                {
                    return "Выберите продукт!!!";
                }
                if (columnName == "Shop" && Shop == null)
                {
                    return "Выберите магазин!!!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ProductShopId { get; set; }

        public Product? Product { get; set; }

        
        public Shop? Shop { get; set; }

        public string? Link { get; set; }
    }
}
