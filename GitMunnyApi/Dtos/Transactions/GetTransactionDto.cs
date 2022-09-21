using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitMunnyApi.Dtos.Transactions
{
    public class GetTransactionDto
    {
        public DateTime Date { get; } = DateTime.Now;
        public Currency Amount { get; set;}
        public string Vendor { get; set; }
        public string Note{ get; set; }
    }
}