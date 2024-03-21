using System;

namespace BankingApp.Core.Models
{
    public class CreateAccountRequest
    {
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
    }

    public class AccountResponse
    {
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
