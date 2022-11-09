namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionGreaterThan: IApiFilter<TransactionModel>
{ 
    private double Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Amount.HasValue && model.Amount.Value >= Value;
    public TransactionGreaterThan(double value) => Value = value;
}