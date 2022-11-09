namespace GitMunnyApi.Filters.TransactionFilters;

public class GreaterThan: IApiFilter<TransactionModel>
{ 
    private double Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Amount >= Value;
    public GreaterThan(double value) => Value = value;
}