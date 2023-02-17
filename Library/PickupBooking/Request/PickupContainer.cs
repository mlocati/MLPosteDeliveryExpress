using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    internal class PickupContainer : ItemsContainer<Pickup>
    {
        /// <summary>
        /// Dettagli della richiesta di ritiro.
        /// </summary>
        [JsonIgnore]
        public Pickup Pickup { get => this.Item; set => this.Item = value; }
    }
}