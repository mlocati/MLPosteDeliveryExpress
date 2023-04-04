using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class ActionResultItem
    {
        [JsonPropertyName("item")]
        public List<ActionResult> Items { get; set; } = new();
    }
}