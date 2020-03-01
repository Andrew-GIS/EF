using Pr0103SportShop.ViewModel.Command;
using SportShop.DAL;
using SportShop.DAL.Model;
using SportShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Pr0103SportShop.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private StoreRepository<Product> storeRepository;

        public ObservableCollection<Product> Products { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand DefaultCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {

            get { return selectedProduct; }
            set
            {
                this.selectedProduct = value;
                this.OnPropertyChanged("SelectedProduct");
            }
        }

        public ProductViewModel()
        {
            //this.storeRepository = new StoreRepository<Product>(context);
            this.RemoveCommand = new RelayCommand(this.RemoveCommand_Execute);
            this.DefaultCommand = new RelayCommand(this.DefaultCommand_Executer);
            this.AddCommand = new RelayCommand(this.AddCommand_Executer);
            this.SaveCommand = new RelayCommand(this.SaveCommand_Executer);

            this.storeRepository = new StoreRepository<Product>();
            this.Products = new ObservableCollection<Product>(storeRepository.GetProducts());
        }

        //public ObservableCollection<Product> GenerateListOfProducts()
        //{
        //    //Products = new ObservableCollection<Product>
        //    //{
        //    //    new Product {ProductName = "Footboll Ball", ProductModel = "4RTY-12", CountryDistributor = "USA", Price = 25, SportCategory = "Football", Image = $"{Directory.GetCurrentDirectory()}/ball.png"},
        //    //    new Product {ProductName = "Swimming Glass", ProductModel = "Spedoo-80x", CountryDistributor = "Germany", Price = 60, SportCategory = "Swimming", Image = $"{Directory.GetCurrentDirectory()}/SwimmingGlass.png"},
        //    //    new Product {ProductName = "Tenis Racket", ProductModel = "UnD-13", CountryDistributor = "Ukraine", Price = 100, SportCategory = "Tenis", Image = $"{Directory.GetCurrentDirectory()}/tenisRocket.png"},
        //    //    new Product {ProductName = "Swimming Flippers", ProductModel = "Arena 2020", CountryDistributor = "USA", Price = 90, SportCategory = "Swimming", Image = $"{Directory.GetCurrentDirectory()}/flippers.png"}
        //    //};
        //    //return Products;

        //}

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void RemoveCommand_Execute(object obj)
        {
            this.storeRepository.Delete(this.SelectedProduct);
            this.Products.Remove(this.SelectedProduct);
            this.storeRepository.Save();
        }

        public void DefaultCommand_Executer(object obj)
        {
            this.SelectedProduct.ProductName = "default";
            this.SelectedProduct.ProductModel = "default";
            this.SelectedProduct.Price = 0;
            this.SelectedProduct.SportCategory = "default";
            this.SelectedProduct.CountryDistributor = "default";
        }

        public void AddCommand_Executer(object obj)
        {
            var newItem = new Product { CountryDistributor = "default", Price = 0, ProductName = "default", ProductModel = "default", SportCategory = "default"  };
            this.Products.Add(newItem);
            this.storeRepository.Add(newItem);
            

            this.storeRepository.Save();
        }

        public void SaveCommand_Executer(object obj)
        {
            this.storeRepository.Save();
        }
    }
}