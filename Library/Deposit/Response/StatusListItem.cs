using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class StatusListItem
    {
        [JsonPropertyName("item")]
        public List<StatusList> StatusList { get; set; } = new();
    }
}