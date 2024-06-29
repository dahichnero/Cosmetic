using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CosmeticHealth.ViewModels
{
    public class AddSymptomPageViewModel :BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;

        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public SymptomViewModel Symptom { get; set; }
        public AddSymptomPageViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Symptom = new SymptomViewModel();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }

        private void saveChanges()
        {
            Symptom symptom = Symptom.ToSymptom();
            using (CosmeticHeathContext context = new())
            {
                if (symptom.SymptomId == 0)
                {
                    context.Symptoms.Add(symptom);
                }
                else
                {
                    context.Symptoms.Update(symptom);
                }
                try
                {
                    context.SaveChanges();
                    backTo();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Error!");
                }
            }

        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
