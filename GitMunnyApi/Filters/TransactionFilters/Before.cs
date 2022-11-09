namespace GitMunnyApi.Filters.TransactionFilters;

public class Before : IApiFilter<TransactionModel>
{
    private DateTime Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Date <= Value;
    public Before(DateTime value) => Value = value;
}