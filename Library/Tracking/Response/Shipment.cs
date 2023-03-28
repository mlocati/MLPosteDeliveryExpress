using MLPosteDeliveryExpress.Json.Converter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    public class Shipment
    {
        /// <summary>
        /// Lettera di Vettura (7, 13, 18 digit)
        /// LdV Sticker (9 digit)
        /// </summary>
        [JsonPropertyName("waybillNumber")]
        public string WaybillNumber { get; set; } = "";

        /// <summary>
        /// Descrizione del prodotto.
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; } = "";

        /// <summary>
        /// Indica se per la spedizione è possibile attivare le notifiche sms / email.
        /// </summary>
        [JsonPropertyName("NotificationFlag")]
        [JsonConverter(typeof(BooleanAsSN))]
        public bool NotificationsCanBeEnabled { get; set; } = false;

        /// <summary>
        /// Indica se una spedizione è A/R.
        /// </summary>
        [JsonPropertyName("returnFlag")]
        [JsonConverter(typeof(BooleanAsSN))]
        public bool RoundTrip { get; set; } = false;

        /// <summary>
        /// Lista degli eventi di tracciatura della spedizione.
        /// </summary>
        [JsonPropertyName("tracking")]
        public List<Tracking> Tracking { get; set; } = new();
    }
}