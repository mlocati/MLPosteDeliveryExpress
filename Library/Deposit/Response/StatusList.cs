using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class StatusList
    {
        /// <summary>
        /// Da svincolare
        /// Svincolata
        /// Non svincolabile
        /// Richiesta svincolo presa in carico
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        /// <summary>
        /// INGIACENZA
        /// SVINCOLATA
        /// SCADUTA
        /// RICHIESTO
        /// SVINCOLOPR
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Status>))]
        public Status Status { get; set; } = Status.InDeposit;
    }
}