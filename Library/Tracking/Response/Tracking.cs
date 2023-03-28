using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    public class Tracking
    {
        /// <summary>
        /// Data dell’evento.
        /// </summary>
        [JsonPropertyName("data")]
        [JsonConverter(typeof(DateTimeYMDhms))]
        public DateTime Date { get; set; } = new();

        /// <summary>
        /// Descrizione dell’ufficio che ha tracciato l’evento.
        /// </summary>
        /// <example>Genova (GE)</example>
        [MaxLength(46)]
        [JsonPropertyName("officeDescription")]
        public string OfficeDescription { get; set; } = "";

        /// <summary>
        /// Descrizione dell’evento.
        /// </summary>
        /// <example>In transito presso il Centro Operativo Postale</example>
        [MaxLength(255)]
        [JsonPropertyName("StatusDescription")]
        public string StatusDescription { get; set; } = "";

        /// <summary>
        /// Descrizione dell’evento per app.
        /// </summary>
        /// <example>La spedizione è in lavorazione</example>
        [MaxLength(255)]
        [JsonPropertyName("appStatusDescription")]
        public string AppStatusDescription { get; set; } = "";

        /// <summary>
        /// Descrizione dell’evento per IVR.
        /// </summary>
        /// <example>La spedizione è in transito presso il Centro Operativo Postale di #luogo#</example>
        [MaxLength(255)]
        [JsonPropertyName("ivrStatusDescription")]
        public string IVRStatusDescription { get; set; } = "";

        /// <summary>
        /// Descrizione di sintesi dell'evento.
        /// </summary>
        /// <example>La spedizione è in transito presso Genova (GE)</example>
        [MaxLength(255)]
        [JsonPropertyName("synthesisStatusDescription")]
        public string SynthesisStatusDescription { get; set; } = "";

        /// <summary>
        /// Fase della spedizione
        /// </summary>
        /// <example>IN TRANSITO</example>
        [MaxLength(50)]
        [JsonPropertyName("phase")]
        public string Phase { get; set; } = "";

        /// <summary>
        /// Ufficio che ha tracciato l'evento
        /// </summary>
        /// <example>UP</example>
        [MaxLength(2)]
        [JsonPropertyName("officeId")]
        public string OfficeID { get; set; } = "";

        /// <summary>
        /// Codice indentificativo dello status.
        /// </summary>
        /// <example>PCP</example>
        [MaxLength(3)]
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}