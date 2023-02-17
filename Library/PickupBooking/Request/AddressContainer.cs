using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    public class ResultContainer : ItemsContainer<Address>
    {
        /// <summary>
        /// Dettagli della richiesta di ritiro.
        /// </summary>
        [JsonIgnore]
        public Address Address { get => this.Item; set => this.Item = value; }
    }
}