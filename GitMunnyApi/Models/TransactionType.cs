using System.Text.Json.Serialization;

namespace GitMunnyApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionType
    {
        Deposit,
        Withdrawl,
        Payment,
        Transfer,
    }
}