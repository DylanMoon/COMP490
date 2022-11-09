namespace GitMunnyApi.Filters.TransactionFilters;

public class WithId: IApiFilter<TransactionModel>
{
    private Guid Value { get; }
    public Func<TransactionModel, bool> Filter => model => model.Id.Equals(Value);
    public WithId(Guid value) => Value = value;
}