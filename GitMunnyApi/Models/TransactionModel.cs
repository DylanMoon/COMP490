using GitMunnyApi.Dtos.Transactions;

namespace GitMunnyApi.Models
{
    public sealed class TransactionModel
    {
        public Guid Id { get; init; }
        public string? Item {get;set;}
        public DateTime Date { get; set; }
        public double? Amount { get; set;}
        public TransactionType? Type { get; set; } 
        public string? Vendor { get; set; }
        public string? Note{ get; set; }
        public IEnumerable<string>? Tags { get; set; }
        public bool Deleted { get; set; }

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
        
        public static bool operator ==(TransactionModel t1, TransactionModel t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(TransactionModel t1, TransactionModel t2)
        {
            return !(t1 == t2);
        }

        public void Update(TransactionModel other)
        {
            Date = other.Date;
            Amount = other.Amount;
            Type = other.Type;
            Vendor = other.Vendor;
            Note = other.Note;
            Tags = other.Tags;
        }

        public void Update(TransactionDto other)
        {
            Amount = other.Amount;
            Type = other.Type;
            Vendor = other.Vendor;
            Note = other.Note;
            Tags = other.Tags;
        }

        public TransactionModel()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public TransactionModel(TransactionModel other)
        {
            Id = other.Id;
            Date = other.Date;
            Amount = other.Amount;
            Type = other.Type;
            Vendor = other.Vendor;
            Note = other.Note;
            Tags = other.Tags;
            Deleted = other.Deleted;
        }

        public override string ToString()
        {
            return $"[Transaction {Id.ToString()}]";
        }
    }
}