using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Models
{
    public class StatementRequest
    {
        public int CustomerId { get; set; }
        public string Accounts { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Purpose { get; set; }
        public string DeliveryMode { get; set; }
    }
}
