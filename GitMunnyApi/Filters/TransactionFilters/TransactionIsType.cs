namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionIsType : IApiFilter<TransactionModel>
{
    private TransactionType Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Type.HasValue && model.Type.Value == Value;

    public TransactionIsType(TransactionType value) => Value = value;
}