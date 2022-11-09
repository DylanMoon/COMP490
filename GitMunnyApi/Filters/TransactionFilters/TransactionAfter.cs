namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionAfter : IApiFilter<TransactionModel>
{
    private DateTime Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Date >= Value;
    public TransactionAfter(DateTime value) => Value = value;
}