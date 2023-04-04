using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    internal class AddressItem
    {
        [JsonPropertyName("item")]
        public List<Address> Items { get; set; } = new();
    }
}