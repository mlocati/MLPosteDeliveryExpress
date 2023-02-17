using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class Container
    {
        /// <summary>
        /// Codice identificativo ritiro.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("bookingId")]
        public string BookingID { get; set; } = "";

        [JsonPropertyName("result")]
        public ResultContainer ResultContainer { get; set; } = new();
    }
}