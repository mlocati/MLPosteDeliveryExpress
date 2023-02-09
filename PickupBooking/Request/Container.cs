using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    internal class Container
    {
        /// <summary>
        /// Dettagli della richiesta di ritiro.
        /// </summary>
        [JsonPropertyName("pickup")]
        public PickupContainer PickupContainer { get; set; } = new();
    }
}