using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Extensions;

namespace ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerService customerService;

        private ObservableCollection<Customer> customers;

        private Customer selectedCustomer;

        private ObservableCollection<Order> orders;

        private Order selectedOrder;

        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }

            set
            {
                this.customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return this.selectedCustomer; }

            set
            {
                this.selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return this.orders; }

            set
            {
                this.orders = value;
                OnPropertyChanged();
            }
        }

        public Order SelectedOrder
        {
            get { return this.selectedOrder; }

            set
            {
                this.selectedOrder = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            this.customerService = new CustomerService();
            this.Customers = this.customerService.GetCustomer().ToObservableCollection();
            this.Orders = this.customerService.GetOrder().ToObservableCollection();
        }
    }
}