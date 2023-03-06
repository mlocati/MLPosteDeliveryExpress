using MLPosteDeliveryExpress.Json.Converter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class FoundContainer
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(BooleanOkKo))]
        public bool Success { get; set; } = false;

        /// <summary>
        /// E0001 => Cliente Obbligatorio
        /// E0002 => Limite inferiore superiore a limite superiore
        /// E0003 => Per i parametri inseriti nessun dato estratto
        /// E0004 => Range date troppo ampio (limitare a 10 gg)
        /// E0018 => Delimitare la ricerca
        /// </summary>
        [MaxLength(6)]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; } = "";

        [MaxLength(50)]
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; set; } = "";

        [JsonPropertyName("pickup")]
        public FoundPickupContainer? FoundPickupContainer { get; set; } = null;

        [JsonPropertyName("statusList")]
        public FoundPickupStatusesContainer? FoundPickupStatusesContainer { get; set; } = null;
    }
}