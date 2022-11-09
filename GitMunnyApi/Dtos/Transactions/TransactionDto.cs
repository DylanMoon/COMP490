namespace GitMunnyApi.Dtos.Transactions
{
    public class TransactionDto
    {
        public Guid Id { get; init; }
        public DateTime? Date { get; set; }
        
        public double? Amount { get; set; }
        public TransactionType? Type { get; set; }
        public string? Vendor { get; set; }
        public string? Note{ get; set; }
        public IEnumerable<string>? Tags{ get; set; }
    }
}