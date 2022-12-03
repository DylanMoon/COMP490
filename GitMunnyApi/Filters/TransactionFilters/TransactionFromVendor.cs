namespace GitMunnyApi.Filters.TransactionFilters;

public class TransactionFromVendor : IApiFilter<TransactionModel>
{ 
    private string Value { get; }

    public Func<TransactionModel, bool> Filter =>
        model => model.Vendor?.Equals(Value, StringComparison.InvariantCultureIgnoreCase) ?? false;
    public TransactionFromVendor(string value) => Value = value;
}