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
    public class BrandViewModel : BaseViewModel, IDataErrorInfo
    {
        public BrandViewModel()
        {
        }

        public BrandViewModel(Brand brand)
        {
            BrandId = brand.BrandId;
            NameBrand=brand.NameBrand;
            DateFound=brand.DateFound;
            Rating=brand.Rating;
        }

        public Brand ToBrand() => new Brand
        {
            BrandId=BrandId,
            NameBrand=NameBrand,
            DateFound=DateFound,
            Rating=Rating,
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "NameBrand" && string.IsNullOrWhiteSpace(NameBrand))
                {
                    return "Название бренда не может быть пустым!";
                }
                if (columnName == "NameBrand" && NameBrand.Length >= 100)
                {
                    return "Название бренда не может содержать более 100 знаков!";
                }
                if (columnName == "DateFound" && DateFound >DateTime.Now)
                {
                    return "Дата основания не должна быть больше сегодняшней даты!";
                }
                if (columnName == "DateFound" && DateFound == null)
                {
                    return "Дата должна быть указана";
                }
                if (columnName == "Rating" && Rating > 5 && Rating<1)
                {
                    return "Рейтинг находится в диапозоне от 1 до 5!";
                }
                return null!;
            }
        }

        public string Error => null!;



        public int BrandId { get; set; }

        public string NameBrand { get; set; } = null!;

        public DateTime DateFound { get; set; }

        public double Rating { get; set; }
    }
}
