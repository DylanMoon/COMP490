namespace GitMunnyApi.Filters.TransactionFilters;

public class FromVendor : IApiFilter<TransactionModel>
{ 
    private string Value { get; }

    public Func<TransactionModel, bool> Filter =>
        model => model.Vendor.Equals(Value, StringComparison.InvariantCultureIgnoreCase);
    public FromVendor(string value) => Value = value;
}