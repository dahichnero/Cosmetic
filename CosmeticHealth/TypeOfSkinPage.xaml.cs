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

namespace CosmeticHealth
{
    /// <summary>
    /// Логика взаимодействия для TypeOfSkinPage.xaml
    /// </summary>
    public partial class TypeOfSkinPage : Page
    {
        //public ObservableCollection<TypeOfSkin> TypeOfSkins { get; private set; }
        const int num = 4;
        public TypeOfSkinPage(HealthWindowViewModel healthWindow)
        {
            //TypeOfSkins = new ObservableCollection<TypeOfSkin>(Session.Instance.Context.TypeOfSkins);
            InitializeComponent();
            DataContext = new TypeOfSkinPageViewModel(healthWindow);
        }
    }
}
