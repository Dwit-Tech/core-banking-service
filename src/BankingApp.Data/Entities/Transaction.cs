using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Entities
{
    public class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }

        public enum TransactionType
        {
            Deposit,
            Withdrawal
        }
    }
}
