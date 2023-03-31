using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class ReasonListItem
    {
        [JsonPropertyName("item")]
        public List<ReasonList> ReasonList { get; set; } = new();
    }
}