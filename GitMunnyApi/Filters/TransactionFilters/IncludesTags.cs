namespace GitMunnyApi.Filters.TransactionFilters;

public class IncludesTags : IApiFilter<TransactionModel>
{
    private IEnumerable<string> Value { get; }

    public Func<TransactionModel, bool> Filter => model => Value.All(tag => model.Tags?.Contains(tag) ?? false);
    public IncludesTags(IEnumerable<string> value) => Value = value;
}