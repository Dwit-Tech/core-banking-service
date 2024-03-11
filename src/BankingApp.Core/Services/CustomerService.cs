using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data;
using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingApp.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _customerDbContext;
        public CustomerService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }
        public async Task<Customer> RequestCustomer(CustomerRequest request)
        {
            Customer customer = new Customer()
            {
                CustomerId = request.CustomerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Address = request.Address,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country,
                State = request.State,
                Email = request.Email,
                IdType = request.IdType,
                PhoneNumber = request.PhoneNumber,
                IdNumber = request.IdNumber,
                BVN = request.BVN,
                BirthDate = request.BirthDate,
                AddedAt = DateTime.UtcNow,
                LastUpdatedBy = "system",
            };

            var created = await _customerDbContext.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
            return created.Entity;
        }
    }
}

