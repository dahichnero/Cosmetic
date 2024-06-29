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
    /// Логика взаимодействия для AddProblemTypeOfSkin.xaml
    /// </summary>
    public partial class AddProblemTypeOfSkin : Page
    {
        const int num = 12;
        //public ObservableCollection<TypeOfSkin> TypeOfSkins { get; private set; }
        //public ObservableCollection<Problem> Problems { get; private set; }

        public AddProblemTypeOfSkin(HealthWindowViewModel healthWindowViewModel)
        {
            //TypeOfSkins = new ObservableCollection<TypeOfSkin>(Session.Instance.Context.TypeOfSkins);
            //Problems = new ObservableCollection<Problem>(Session.Instance.Context.Problems);
            InitializeComponent();
            DataContext = new AddProblemTypeOfSkinViewModel(healthWindowViewModel);
        }
    }
}
