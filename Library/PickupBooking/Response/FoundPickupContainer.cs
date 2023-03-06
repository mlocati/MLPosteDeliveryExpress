using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class FoundPickupContainer
    {
        [JsonPropertyName("item")]
        public List<FoundPickup> Items { get; set; } = new();
    }
}