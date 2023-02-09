using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class ResultContainer : ItemsContainer<Result>
    {
        /// <summary>
        /// Risultato della richiesta di ritiro.
        /// </summary>
        [JsonIgnore]
        public Result Result { get => this.Item; set => this.Item = value; }
    }
}