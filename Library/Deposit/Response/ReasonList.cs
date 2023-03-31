using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class ReasonList
    {
        /// <summary>
        /// Rifiuto del destinatario
        /// Destinatario non individuabile
        /// Indirizzo Errato
        /// Destinatario Assente
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        /// <summary>
        /// RIFDEST
        /// DESTNOTIND
        /// INDERR
        /// DESTASS
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Reason>))]
        public Reason Reason { get; set; } = Reason.RejectedByRecipient;
    }
}