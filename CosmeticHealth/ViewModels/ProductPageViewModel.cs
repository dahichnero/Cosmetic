using CosmeticHealth.Commands;
using CosmeticHealth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CosmeticHealth.ViewModels
{
    internal class ProductPageViewModel :BaseViewModel
    {
        private readonly HealthWindowViewModel healthWindowViewModel;
        public ListCollectionView Products { get; set; }
        public List<TypeOfSkin> TypeOfSkins { get; set; }
        public List<TypeOfProduct> TypeOfProducts { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Problem> Problems { get; set; }
        public List<Irritant> Irritants { get; set; }
        public List<ProductProblem> ProductProblems { get; set; }
        static TypeOfSkin typeOfSkin;
        static TypeOfProduct typeOfProduct;
        static Brand brand;
        static Problem problem;
        static Irritant irritant;

        public ListCollectionView ProductsWithProblems { get; set; }
        public RelayCommand FullProduct { get; set; }
        public RelayCommand DeleteProduct { get; set; }

        public RelayCommand UpdateProduct { get; set; }
        public RelayCommand UpdateProductShop { get; set; }
        public RelayCommand UpdateProductProblem { get; set; }
        public RelayCommand UpdateProductIngredient { get; set; }

        public bool HideOrNot { get; set; }
        public ProductPageViewModel(HealthWindowViewModel healthWindowViewModel)
        {
            this.healthWindowViewModel = healthWindowViewModel;
            HideOrNot = healthWindowViewModel.AdminOrClient;
            using (CosmeticHeathContext context = new())
            {
                Products = new ListCollectionView(context.Products.Include(p => p.BrandNavigation).Include(s => s.TypeOfSkinNavigation).Include(q => q.TypeNavigation).ToList());
                TypeOfSkins = context.TypeOfSkins.ToList();
                typeOfSkin = new TypeOfSkin
                {
                    TypeOfSkinId = 0,
                    TypeOfSkinName = "Все"
                };
                TypeOfSkins.Insert(0, typeOfSkin);
                TypeOfProducts = context.TypeOfProducts.ToList();
                typeOfProduct = new TypeOfProduct
                {
                    TypeOfProductId = 0,
                    NameTypeOfProduct = "Все"
                };
                TypeOfProducts.Insert(0, typeOfProduct);
                Brands=context.Brands.ToList();
                brand = new Brand {
                    BrandId = 0,
                    NameBrand = "Все",
                    DateFound = DateTime.Now,
                    Rating = 5
                };
                Brands.Insert(0,brand);
                Problems=context.Problems.ToList();
                problem = new Problem
                {
                    ProblemId = 0,
                    ProblemName="Все проблемы",
                    YearsToSolve=1
                };
                Problems.Insert(0,problem);
                Irritants=context.Irritants.ToList();
                irritant = new Irritant
                {
                    IrritantId = 0,
                    IrritantName = "Все"
                };
                Irritants.Insert(0,irritant);
                FullProduct = new RelayCommand(_ => navigateToProductFull(SelectedProduct?.ProductId ?? 0));
                DeleteProduct = new RelayCommand(_=>delete(SelectedProduct));
                UpdateProduct=new RelayCommand(_=>navigateToUpdateProduct(SelectedProduct?.ProductId ?? 0));
                UpdateProductShop=new RelayCommand((_=>navigateToUpdateProductShop(SelectedProduct?.ProductId ?? 0)));
                UpdateProductProblem=new RelayCommand(_=>navigateToUpdateProductProblem(SelectedProduct?.ProductId ?? 0));
                UpdateProductIngredient = new RelayCommand(_ => navigateToUpdateProductIngredient(SelectedProduct?.ProductId ?? 0));
            }
            
        }
        private Product? selectedProduct;
        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                setAndNotify(ref selectedProduct, value);
                notifyPropertyChanged(nameof(CanEditProduct));
            }
        }
        public bool CanEditProduct => selectedProduct != null;

        private string searchString = string.Empty;
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                Products.Filter=p=>filterPredicate((Product)p);
            }
        }

        public void delete(Product product)
        {
            using (CosmeticHeathContext context = new())
            {
                try
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    Products.Remove(product);
                    MessageBox.Show("Продукт удален", "Удаление успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool filterPredicate(Product product)
        {
            if (selectedTypeOfProduct is null && selectedTypeOfSkin is null && selectedBrand is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase);
            }


            if (selectedTypeOfProduct is null && selectedTypeOfSkin is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Brand == selectedBrand.BrandId || selectedBrand.BrandId == 0);
            }
            if (selectedTypeOfProduct is null && selectedBrand is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0);
            }
            if (selectedTypeOfSkin is null && selectedBrand is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Type == selectedTypeOfProduct.TypeOfProductId ||
                selectedTypeOfProduct.TypeOfProductId == 0);
            }
            if (selectedTypeOfProduct is null && selectedTypeOfSkin is null && selectedBrand is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Irritant == selectedIrritant.IrritantId ||
                selectedIrritant.IrritantId == 0);
            }


            if (selectedTypeOfProduct is null && selectedTypeOfSkin is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0) && (product.Brand==selectedBrand.BrandId || selectedBrand.BrandId==0);
            }
            if (selectedTypeOfProduct is null && selectedBrand is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0) && (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0);
            }
            if (selectedTypeOfProduct is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Brand == selectedBrand.BrandId
                || selectedBrand.BrandId == 0) && (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0);
            }
            if (selectedTypeOfSkin is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Brand == selectedBrand.BrandId
                || selectedBrand.BrandId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId || selectedTypeOfProduct.TypeOfProductId == 0);
            }
            if (selectedTypeOfSkin is null && selectedBrand is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId || selectedTypeOfProduct.TypeOfProductId == 0);
            }
            if (selectedBrand is null && selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId
                || selectedTypeOfSkin.TypeOfSkinId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId || selectedTypeOfProduct.TypeOfProductId == 0);
            }


            if (selectedTypeOfSkin is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) && (product.Type == selectedTypeOfProduct.TypeOfProductId ||
                selectedTypeOfProduct.TypeOfProductId == 0) && (product.Brand == selectedBrand.BrandId || selectedBrand.BrandId == 0)
                && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0);
            }
            if (selectedTypeOfProduct is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0) && (product.Brand == selectedBrand.BrandId || selectedBrand.BrandId == 0)
                && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0);
            }
            if (selectedBrand is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId ||
                selectedTypeOfProduct.TypeOfProductId == 0) && (product.Irritant == selectedIrritant.IrritantId
                || selectedIrritant.IrritantId == 0);
            }
            if (selectedIrritant is null)
            {
                return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId ||
                selectedTypeOfProduct.TypeOfProductId == 0) && (product.Brand == selectedBrand.BrandId || selectedBrand.BrandId == 0);
            }
            
            return product.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                (product.TypeOfSkin == selectedTypeOfSkin.TypeOfSkinId || selectedTypeOfSkin.TypeOfSkinId == 0) && (product.Type == selectedTypeOfProduct.TypeOfProductId ||
                selectedTypeOfProduct.TypeOfProductId == 0) && (product.Brand == selectedBrand.BrandId || selectedBrand.BrandId==0) && (product.Irritant==selectedIrritant.IrritantId
                || selectedIrritant.IrritantId==0);
        }


        private TypeOfSkin selectedTypeOfSkin;
        public TypeOfSkin SelectedTypeOfSkin
        {
            get
            {
                return selectedTypeOfSkin;
            }
            set
            {
                selectedTypeOfSkin = value;
                Products.Filter = p => filterPredicate((Product)p);
            }
        }
        private TypeOfProduct selectedTypeOfProduct;
        public TypeOfProduct SelectedTypeOfProduct
        {
            get
            {
                return selectedTypeOfProduct;
            }
            set
            {
                selectedTypeOfProduct= value;
                Products.Filter=p => filterPredicate((Product)p);
            }

        }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get
            {
                return selectedBrand;
            }
            set
            {
                selectedBrand = value;
                Products.Filter = p => filterPredicate((Product)p);
            }

        }

        private Irritant selectedIrritant;

        public Irritant SelectedIrritant
        {
            get
            {
                return selectedIrritant;
            }
            set
            { 
                selectedIrritant = value;
                Products.Filter = p => filterPredicate((Product)p);
            }
        }



        private void navigateToProductFull(int productId)
        {
            healthWindowViewModel.NavigateProductFullPage(productId);
        }

        private void navigateToUpdateProduct(int productId)
        {
            healthWindowViewModel.NavigateToUpdateProduct(productId);
        }

        private void navigateToUpdateProductShop(int productId)
        {
            healthWindowViewModel.NavToUpPageShop(productId);
        }

        private void navigateToUpdateProductProblem(int productId)
        {
            healthWindowViewModel.NavToUpPageProblem(productId);
        }

        private void navigateToUpdateProductIngredient(int productId)
        {
            healthWindowViewModel.NavToUpPageIng(productId);
        }
    }
}
