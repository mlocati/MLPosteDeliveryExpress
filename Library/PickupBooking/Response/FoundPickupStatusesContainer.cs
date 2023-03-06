using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class FoundPickupStatusesContainer
    {
        [JsonPropertyName("item")]
        public List<FoundPickupStatus> Items { get; set; } = new();
    }
}