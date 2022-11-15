namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionNotDeleted : IApiFilter<TransactionModel>
{
    public Func<TransactionModel, bool> Filter => model => !model.Deleted;
}