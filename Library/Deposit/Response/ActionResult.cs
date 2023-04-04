using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class ActionResult
    {
        [MaxLength(50)]
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; set; } = "";

        [MaxLength(6)]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; } = "";

        [JsonPropertyName("result")]
        [JsonConverter(typeof(Json.Converter.BooleanOkKo))]
        public bool Result { get; set; } = false;

        /// <summary>
        /// ID LDV.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("barcode")]
        public string BarCode { get; set; } = "";
    }
}