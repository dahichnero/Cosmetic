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
    public class ShopViewModel : BaseViewModel, IDataErrorInfo
    {
        public ShopViewModel()
        {
        }

        public ShopViewModel(Shop shop)
        {
            ShopId = shop.ShopId;
            NameShop=shop.NameShop;
            UrAddress=shop.UrAddress;
        }

        public Shop ToShop() => new Shop
        {
            ShopId = ShopId,
            NameShop=NameShop,
            UrAddress=UrAddress,
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "NameShop" && string.IsNullOrWhiteSpace(NameShop))
                {
                    return "Название магазина не может быть пустым";
                }
                if (columnName == "NameShop" && NameShop.Length >= 100)
                {
                    return "Название магазина не может содержать более 100 знаков!";
                }
                if (columnName == "UrAddress" && string.IsNullOrWhiteSpace(UrAddress))
                {
                    return "Название адреса не может быть пустым!";
                }
                if (columnName == "UrAddress" && UrAddress.Length >= 200)
                {
                    return "Название адреса не может содержать более 200 знаков!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ShopId { get; set; }

        public string NameShop { get; set; } = null!;

        public string UrAddress { get; set; } = null!;
    }
}
