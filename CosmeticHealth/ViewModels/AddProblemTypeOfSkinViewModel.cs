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
    public class AddProblemTypeOfSkinViewModel:BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public RelayCommand Accept { get; set; }
        public RelayCommand Back { get; set; }
        public List<TypeOfSkin> TypeOfSkins { get; set; }
        public List<Problem> Problems { get; set; }
        public ProblemTypeOfSkinViewModel ProblemTypeOfSkin { get; set; }
        public AddProblemTypeOfSkinViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                ProblemTypeOfSkin = new ProblemTypeOfSkinViewModel();
                Problems = context.Problems.ToList();
                TypeOfSkins = context.TypeOfSkins.ToList();
                Back = new RelayCommand(_ => backTo());
                Accept = new RelayCommand(_ => saveChanges());
            }
        }
        private void saveChanges()
        {
            ProblemTypeOfSkin problemType = ProblemTypeOfSkin.ToProbType();
            using (CosmeticHeathContext context = new())
            {
                context.ProblemTypeOfSkins.Add(problemType);
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
