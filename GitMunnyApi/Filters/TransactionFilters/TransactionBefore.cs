namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionBefore : IApiFilter<TransactionModel>
{
    private DateTime Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Date <= Value;
    public TransactionBefore(DateTime value) => Value = value;
}