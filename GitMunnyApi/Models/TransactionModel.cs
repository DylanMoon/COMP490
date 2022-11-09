namespace GitMunnyApi.Models
{
    public sealed class TransactionModel
    {
        public Guid Id { get; init; }
        public DateTime Date { get; } = DateTime.Now;
        public double? Amount { get; set;}
        public TransactionType? Type { get; set; } 
        public string? Vendor { get; set; }
        public string? Note{ get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool Deleted { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        //TODO: need update method for easier use
        //TODO: possibly a copy constructor
        
    }
}