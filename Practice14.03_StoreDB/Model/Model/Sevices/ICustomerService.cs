using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomer();
        IEnumerable<Order> GetOrder();
    }
}