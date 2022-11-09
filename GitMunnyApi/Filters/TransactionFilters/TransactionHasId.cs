namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionHasId: IApiFilter<TransactionModel>
{
    private Guid Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Id.Equals(Value);
    public TransactionHasId(Guid value) => Value = value;
}