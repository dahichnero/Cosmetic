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
    public class SymptomViewModel : BaseViewModel, IDataErrorInfo
    {
        public SymptomViewModel()
        {
        }

        public SymptomViewModel(Symptom symptom)
        {
            SymptomId=symptom.SymptomId;
            NameSymptom = symptom.NameSymptom;
            Description = symptom.Description;
        }

        public Symptom ToSymptom() => new Symptom
        {
            SymptomId = SymptomId,
            NameSymptom = NameSymptom,
            Description = Description
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "NameSymptom" && string.IsNullOrWhiteSpace(NameSymptom))
                {
                    return "Название симптома не может быть пустым!";
                }
                if (columnName == "NameSymptom" && NameSymptom.Length >= 200)
                {
                    return "Название симптома не может содержать более 200 знаков!";
                }
                if (columnName == "Description" && string.IsNullOrWhiteSpace(Description))
                {
                    return "Описание не может быть пустым!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int SymptomId { get; set; }

        public string NameSymptom { get; set; } = null!;

        public string? Description { get; set; }
    }
}
