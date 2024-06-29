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
    public class ProblemTypeOfSkinViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProblemTypeOfSkinViewModel()
        {
        }

        public ProblemTypeOfSkinViewModel(ProblemTypeOfSkin problemTypeOfSkin)
        {
            ProductTypeId = problemTypeOfSkin.ProductTypeId;
            Problem=problemTypeOfSkin.ProblemNavigation;
            TypeOfSkin = problemTypeOfSkin.TypeOfSkinNavigation;
        }

        public ProblemTypeOfSkin ToProbType() => new ProblemTypeOfSkin
        {
            ProductTypeId=ProductTypeId,
            Problem=Problem!.ProblemId,
            TypeOfSkin=TypeOfSkin!.TypeOfSkinId,
        };
        public string this[string columnName]
        {
            get
            {
                
                if (columnName == "Problem" && Problem == null)
                {
                    return "Выберите проблему!!!";
                }
                if (columnName == "TypeOfSkin" && TypeOfSkin == null)
                {
                    return "Выберите тип кожи!!!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ProductTypeId { get; set; }
        public Problem? Problem { get; set; }

        public TypeOfSkin? TypeOfSkin { get; set; }
    }
}
