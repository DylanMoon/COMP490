namespace GitMunnyApi.Filters.TransactionFilters;

public class After : IApiFilter<TransactionModel>
{
    private DateTime Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Date >= Value;
    public After(DateTime value) => Value = value;
}