using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    internal class FilterContainer
    {
        /// <summary>
        /// Indica le tipologie di ritiro.
        /// </summary>
        [JsonPropertyName("pickupFilter")]
        public Filter Filter { get; set; } = new();
    }
}