namespace GitMunnyApi.Filters.TransactionFilters;

public class LessThan : IApiFilter<TransactionModel>
{
    private double Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Amount <= Value;
    public LessThan(double value) => Value = value;
}