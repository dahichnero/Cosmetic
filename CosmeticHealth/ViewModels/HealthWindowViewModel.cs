using CosmeticHealth.AddPages;
using CosmeticHealth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CosmeticHealth.ViewModels
{
    public class HealthWindowViewModel :BaseViewModel
    {
        public bool AdminOrClient { get; set; }
        public HealthWindowViewModel(bool adminOrClient)
        {
            NavigateProductsPage();
            AdminOrClient = adminOrClient;
            CloseCommand = new RelayCommand(_=>closeProgram());
            AddCommand = new RelayCommand(_ => addWhat());
            TypeOfSkinWhat = new RelayCommand(_ => skin());
            HelpWith = new RelayCommand(_ => help());
        }
        
        public void help()
        {
            CurrentPage=new ChooseSymptomPage(this);
        }
        public void skin()
        {
            CurrentPage = new TypeOfSkinPage(this);
        }
        public void addWhat()
        {
            WhatAddWindow whatAddWindow = new WhatAddWindow();
            whatAddWindow.ShowDialog();
            switch (whatAddWindow.NumPage)
            {
                case 5:
                    CurrentPage= new AddProductPage(this,0);
                    break;
                case 6:
                    CurrentPage=new AddProblemPage(this);
                    break;
                case 7:
                    CurrentPage=new AddBrandPage(this);
                    break;
                case 8:
                    CurrentPage=new AddSymptomPage(this);
                    break;
                case 9:
                    CurrentPage=new AddIngridientPage(this);
                    break;
                case 10:
                    CurrentPage=new AddShopPage(this);
                    break;
                case 11:
                    CurrentPage=new AddProblemSymptom(this);
                    break;
                case 12:
                    CurrentPage=new AddProblemTypeOfSkin(this);
                    break;
                case 13:
                    CurrentPage=new AddProductProblem(this,0);
                    break;
                case 14:
                    CurrentPage=new AddPoductShop(this,0);
                    break;
                case 15:
                    CurrentPage=new AddProductIngridient(this,0);
                    break;
            }
        }
        private void closeProgram()
        {
            Environment.Exit(0);
        }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand TypeOfSkinWhat { get; set; }
        public RelayCommand HelpWith { get; set; }
        public RelayCommand Backs { get; set; }

        private Page currentPage = null!;
        public Page CurrentPage
        {
            get=> currentPage;
            set=> setAndNotify(ref currentPage, value);
        }
        public void NavigateProductsPage()
        {
            CurrentPage = new ProductPage(this);
        }

        public void NavigateProductFullPage(int productId)
        {
            CurrentPage = new ProductFullPage(this, productId);
        }

        public void NavigateToUpdateProduct(int productId)
        {
            CurrentPage = new AddProductPage(this,productId);
        }

        public void NavigatetoUpdateProductShop(int productShopId)
        {
            CurrentPage=new AddPoductShop(this, productShopId);
        }
        public void NavToUpPageShop(int productId)
        {
            CurrentPage=new UpdateProductShop(this,productId);
        }

        public void NavigatetoUpdateProductProblem(int productProblemId)
        {
            CurrentPage = new AddProductProblem(this, productProblemId);
        }
        public void NavToUpPageProblem(int productId)
        {
            CurrentPage=new UpdateProductProblem(this, productId);
        }

        public void NavigatetoUpdateProductIngredient(int productIngredientId)
        {
            CurrentPage = new AddProductIngridient(this, productIngredientId);
        }
        public void NavToUpPageIng(int productId)
        {
            CurrentPage = new UpdateProductIngredient(this, productId);
        }

        
    }
}
