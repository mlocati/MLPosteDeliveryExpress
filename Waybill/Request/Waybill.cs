using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class Waybill
    {
        /// <summary>
        /// Identificativo della spedizione univoco per il cliente.
        /// </summary>
        [MaxLength(25)]
        [JsonPropertyName("clientReferenceId")]
        public string? ClientReferenceId { get; set; } = null;

        /// <summary>
        /// Parametro che indica il formato della LDV da stampare.
        /// </summary>
        [JsonPropertyName("printFormat")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<PrintFormat>))]
        public PrintFormat PrintFormat { get; set; } = PrintFormat.PDF_A4;

        /// <summary>
        /// Codice aptus del prodotto.
        /// </summary>
        [JsonPropertyName("product")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<AptusCode>))]
        public AptusCode Product { get; set; } = AptusCode.PosteDeliveryBusinessExpress;

        [JsonPropertyName("data")]
        public WaybillData Data { get; set; } = new();
    }
}