using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitMunnyApi.Models
{
    public class Transaction
    {
         public Transaction(int id, Currency amount){
            Id = id;
            Amount = amount;
        }
        public int Id { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public Currency Amount { get; set;}
        public string Vendor { get; set; }
        public string Note{ get; set; }
        public bool Deleted { get; set; }
        // Category
        // Flags
        // Location lat long?
        // icon to use, also db user should have a map of category strings and icons tied, that we pass up keys when a new transaction prompt is displayed with available categories or add new
    }
}