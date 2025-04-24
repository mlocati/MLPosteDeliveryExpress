using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class WaybillDataInternational
    {
        /// <summary>
        /// Vettore internazionale.
        /// Viene assegnato automaticamente da sistema.
        /// </summary>
        [JsonPropertyName("carrier")]
        public string? Carrier { get; set; } = null;

        /// <summary>
        /// Obbligatorio solo internazionale.
        /// </summary>
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<ReceiverType>))]
        [JsonPropertyName("receiverType")]
        public ReceiverType ReceiverType { get; set; } = ReceiverType.RetailDelivery;

        /// <summary>
        /// Valuta della spedizione.
        /// Codice ISO a tre caratteri.
        /// Es: EUR
        /// Obbligatorio per prodotto APT000903 spedizioni EUE.
        /// </summary>
        [RegularExpression("^[A-Z]{3}$")]
        [JsonPropertyName("currency")]
        public string? Currency { get; set; } = null;

        /// <summary>
        /// Valore totale della spedizione.
        /// Obbligatorio per prodotto APT000903 spedizioni EUE.
        /// </summary>
        [JsonPropertyName("waybillTotalValue")]
        public uint? WaybillTotalValue { get; set; } = null;

        /// <summary>
        /// Campo note della spedizione.
        /// </summary>
        [JsonPropertyName("note")]
        public string? Notes { get; set; } = null;

        /// <summary>
        /// Codice identificativo del tipo di contenuto per internazionale.
        /// Obbligatorio per prodotto internazionale APT000904 e APT001013.
        /// </summary>
        [MaxLength(3)]
        [JsonPropertyName("contentCode")]
        public string? ContentCode { get; set; } = null;
    }
}