using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitMunnyApi.Dtos.Transactions
{
    public class TransactionDto
    {
        public Guid Id { get; init; }
        public double Amount { get; set;}
        public string Vendor { get; set; }
        public string Note{ get; set; }
    }
}