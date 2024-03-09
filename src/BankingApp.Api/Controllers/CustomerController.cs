using Microsoft.AspNetCore.Mvc;
using BankingApp.Core.Interfaces;
using BankingApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Customer> customers = await _customerService.GetCustomers();

            if (customers is null || customers.Count == 0)
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }
}