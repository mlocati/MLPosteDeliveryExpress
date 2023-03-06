using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    public class FoundPickupStatus
    {
        [MaxLength(50)]
        [JsonPropertyName("statusDescription")]
        public string Description { get; set; } = "";

        [MaxLength(20)]
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}