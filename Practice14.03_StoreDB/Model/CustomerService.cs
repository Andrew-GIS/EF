using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CustomerService : ICustomerService
    {
        private StoreContext context;

        public CustomerService()
        {
            context = new StoreContext();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return this.context.Customers.Include(customer => customer.Orders);
        }

        public IEnumerable<Order> GetOrder()
        {
            return this.context.Orders.Include(order => order.OrderItems).Include(order => order.Staff).Include(order => order.Store);
        }
    }
}
