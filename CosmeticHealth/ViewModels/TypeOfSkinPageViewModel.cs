using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticHealth.ViewModels
{
    public class TypeOfSkinPageViewModel : BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;

        public List<TypeOfSkin> TypeOfSkins { get; set; }
        public RelayCommand BackTo { get; set; }
        public TypeOfSkinPageViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                TypeOfSkins = context.TypeOfSkins.ToList();
                BackTo = new RelayCommand(_ => backTo());
            }
        }
        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
