namespace GitMunnyApi.Dtos.Transactions;

public class UpdateTransactionDto
{
    public int Id { get; set; }
    public Currency Amount { get; set;}
    public string Vendor { get; set; }
    public string Note{ get; set; }
    public bool Deleted { get; set; }
}