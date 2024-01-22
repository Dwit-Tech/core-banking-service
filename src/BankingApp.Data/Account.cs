using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountHolderName { get; set; }

        public Account(string accountHolderName)
        {
            AccountHolderName = accountHolderName;
        }

        public decimal Balance { get; set; }
    }

}
