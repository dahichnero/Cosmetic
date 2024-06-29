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
    public class AddProblemPageViewModel: BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;

        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public ProblemViewModel Problem { get; set; }
        public AddProblemPageViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Problem = new ProblemViewModel();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }

        private void saveChanges()
        {
            Problem problem = Problem.ToProblem();
            using (CosmeticHeathContext context = new())
            {
                if (problem.ProblemId == 0)
                {
                    context.Problems.Add(problem);
                }
                else
                {
                    context.Problems.Update(problem);
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
