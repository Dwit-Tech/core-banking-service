using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.Models;
using BankingApp.Data.Entities;

namespace BankingApp.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> RequestCustomer(CustomerRequest request);
    }
}

