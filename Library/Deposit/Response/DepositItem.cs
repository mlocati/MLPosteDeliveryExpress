using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class DepositItem
    {
        [JsonPropertyName("item")]
        public List<Deposit> Deposits { get; set; } = new();
    }
}