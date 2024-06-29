using CosmeticHealth.Models;
using CosmeticHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CosmeticHealth.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddProblemSymptom.xaml
    /// </summary>
    public partial class AddProblemSymptom : Page
    {
        const int num = 11;
        //public ObservableCollection<Problem> Problems { get; private set; }
        //public ObservableCollection<Symptom> Symptoms { get; private set; }
        public AddProblemSymptom(HealthWindowViewModel healthWindowViewModel)
        {
            //Problems = new ObservableCollection<Problem>(Session.Instance.Context.Problems);
            //Symptoms = new ObservableCollection<Symptom>(Session.Instance.Context.Symptoms);
            InitializeComponent();
            DataContext = new AddProblemSymptomViewModel(healthWindowViewModel);
        }
    }
}
