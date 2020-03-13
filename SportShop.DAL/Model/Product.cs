using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SportShop.DAL.Model
{
    public class Product : INotifyPropertyChanged
    {
        public static int counter = 1;

        public int ProductId { get; set; }

        private string productName;

        private string productModel;

        private string countryDistributor;

        private decimal price;

        private string sportCategory;

        private string image;

        public int Id { get; set; }

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public string ProductModel
        {
            get { return productModel; }
            set
            {
                productModel = value;
                OnPropertyChanged("ProductModel");
            }
        }

        public string CountryDistributor
        {
            get { return countryDistributor; }
            set
            {
                countryDistributor = value;
                OnPropertyChanged("CountryDistributor");
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string SportCategory
        {
            get { return sportCategory; }
            set
            {
                sportCategory = value;
                OnPropertyChanged("SportCategory");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Product()
        {
            //Id = counter++;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return $" {Image} {ProductName} - {ProductModel} ";
        }
    }
}
