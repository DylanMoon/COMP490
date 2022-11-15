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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj) =>
            obj switch
            {
                TransactionModel otherModel => Id.Equals(otherModel.Id),
                TransactionDto otherDto => Id.Equals(otherDto.Id),
                Guid otherGuid => Id.Equals(otherGuid),
                _ => false
            };
        
        public static bool operator ==(TransactionDto t1, TransactionDto t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(TransactionDto t1, TransactionDto t2)
        {
            return !(t1 == t2);
        }
    }
}