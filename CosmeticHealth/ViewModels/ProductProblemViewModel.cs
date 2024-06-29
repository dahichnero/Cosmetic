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
    public class ProductProblemViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProductProblemViewModel()
        {
        }

        public ProductProblemViewModel(ProductProblem productProblem)
        {
            ProductProblemId=productProblem.ProductProblemId;
            Product=productProblem.ProductNavigation;
            Problem=productProblem.ProblemNavigation;
        }

        public ProductProblem ToProdProb() => new ProductProblem
        {
            ProductProblemId=ProductProblemId,
            Product=Product!.ProductId,
            Problem=Problem!.ProblemId,
        };
        public string this[string columnName]
        {
            get
            {
                
                if (columnName == "Product" && Product == null)
                {
                    return "Выберите продукт!!!";
                }
                if (columnName == "Problem" && Problem == null)
                {
                    return "Выберите проблему!!!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ProductProblemId { get; set; }
        public Product? Product { get; set; }

        public Problem? Problem { get; set; }
    }
}
