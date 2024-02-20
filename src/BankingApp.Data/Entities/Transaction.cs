using System;
using BankingApp.Data.Enums;

namespace BankingApp.Data.Entities
{
    public class Transaction : BaseEntity
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime ValueDate { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        }
}
