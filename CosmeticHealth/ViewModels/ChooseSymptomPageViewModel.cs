using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CosmeticHealth.ViewModels
{
    public class ChooseSymptomPageViewModel : BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public List<Symptom> Symptoms { get; set; }
        public List<Problem> Problems { get; set; }
        public ListCollectionView ProblemSymptomss { get; set; }
        public ListCollectionView ProblemSymptoms { get; set; }

        List<Symptom> Results = new List<Symptom>();
        public RelayCommand BackTo { get; set; }
        public RelayCommand Choose { get; set; }
        public RelayCommand AddThis { get; set; }

        private RelayCommand _checkCommand;
        //public RelayCommand CheckCommand 
        //{
        //    get
        //    {
        //        if (_checkCommand is null)
        //        {
        //            _checkCommand = new RelayCommand(Check, CanCheck);
        //        }
        //        return _checkCommand;
        //    }
        //}
        public ChooseSymptomPageViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            using (CosmeticHeathContext context = new())
            {
                Symptoms = context.Symptoms.ToList();
                ProblemSymptoms = new ListCollectionView(context.ProblemSymptoms.Include(z=>z.SymptomNavigation).Include(s=>s.ProblemNavigation).ToList());
                Problems=context.Problems.ToList();
                BackTo = new RelayCommand(_ => backTo());
                //Choose = new RelayCommand(_ => Your());
                AddThis = new RelayCommand(_ =>AddS()); 
            }
        }

        //private void Check(object parameter)
        //{
        //    var item = parameter as ListViewItem;
        //    if (item != null)
        //    {
        //        var symptom=item.DataContext as Symptom;
        //        if (symptom != null)
        //        {

        //            SelectedSymptom.AddNewItem(symptom);
        //            MessageBox.Show($"You checked {symptom.NameSymptom}");
        //        }
        //    }
        //}

        private Symptom? selectedSymptom;
        public Symptom? SelectedSymptom
        {
            get => selectedSymptom;
            set
            {
                setAndNotify(ref selectedSymptom, value);
                notifyPropertyChanged(nameof(CanEditProduct));
                ProblemSymptoms.Filter = p => filterPredicate((ProblemSymptom)p);
            }
        }
        public bool CanEditProduct => selectedSymptom != null;

        public bool filterPredicate(ProblemSymptom problemSymptom)
        {
            //var prr = ProblemSymptoms.Join(Problems, z=>z.Problem, x=>x.ProblemId, (z,x)=>new {ProblemName=x.ProblemName, Symptom=z.Symptom});

            //foreach (var sym in Results)
            //{
            //    ProblemSymptomss = new ListCollectionView((System.Collections.IList)prr.Where(x => x.Symptom == sym.SymptomId));
            //}
            return problemSymptom.Symptom == selectedSymptom.SymptomId;
        }

        public void AddS()
        {
            Results.Add(SelectedSymptom);
        }

        private bool CanCheck(object parameter)
        {
            return true;
        }

        public void backTo()
        {
            healthWindowViewModel.NavigateProductsPage();
        }
    }
}
