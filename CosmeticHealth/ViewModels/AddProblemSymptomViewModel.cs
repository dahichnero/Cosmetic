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
    public class AddProblemSymptomViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Problem> Problems  { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public ProblemSymptomViewModel ProblemSymptom { get; set; }
        public AddProblemSymptomViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProblemSymptom = new ProblemSymptomViewModel();
                Problems = context.Problems.ToList();
                Symptoms = context.Symptoms.ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        private void saveChanges()
        {
            ProblemSymptom problemsym = ProblemSymptom.ToProbSym();
            using (CosmeticHeathContext context = new())
            {
                context.ProblemSymptoms.Add(problemsym);
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
