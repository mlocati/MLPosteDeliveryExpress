using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    internal class ShipmentIDItem
    {
        [JsonPropertyName("item")]
        public List<ShipmentID> Items { get; set; } = new();
    }
}