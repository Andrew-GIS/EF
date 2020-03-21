using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ViewModel.Extensions;

namespace ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly IProductService productService;

        private ObservableCollection<Product> products;

        private Product selectedProduct;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }

            set
            {
                this.products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedPoduct
        {
            get { return this.selectedProduct; }

            set
            {
                this.selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            this.productService = new ProductService();
            this.Products = this.productService.GetProduct().ToObservableCollection();
        }
    }
}