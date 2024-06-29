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
    public class ProblemSymptomViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProblemSymptomViewModel()
        {
        }

        public string this[string columnName]
        {
            get
            {
                
                if (columnName == "Problem" && Problem == null)
                {
                    return "Выберите проблему!!!";
                }
                if (columnName == "Symptom" && Symptom == null)
                {
                    return "Выберите симптом!!!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public ProblemSymptomViewModel(ProblemSymptom problemSymptom)
        {
            ProductSyId = problemSymptom.ProductSyId;
            Problem = problemSymptom.ProblemNavigation;
            Symptom=problemSymptom.SymptomNavigation;
        }

        public ProblemSymptom ToProbSym() => new ProblemSymptom
        {
            ProductSyId=ProductSyId,
            Problem=Problem!.ProblemId,
            Symptom=Symptom!.SymptomId,
        };

        public int ProductSyId { get; set; }
        public Problem? Problem { get; set; }

        public Symptom? Symptom { get; set; }
    }
}
