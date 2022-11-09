namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionLessThan : IApiFilter<TransactionModel>
{
    private double Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Amount.HasValue && model.Amount.Value <= Value;
    public TransactionLessThan(double value) => Value = value;
}