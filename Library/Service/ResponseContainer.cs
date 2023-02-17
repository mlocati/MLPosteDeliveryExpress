using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Service
{
    public abstract class ResponseContainer
    {
        /// <summary>
        /// Valore fisso, WEBSERVICES.
        /// </summary>
        [MaxLength(13)]
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = "";

        /// <summary>
        /// Codice del contratto.
        /// </summary>
        [MaxLength(12)]
        [JsonPropertyName("contractCode")]
        public string ContractCode { get; set; } = "";

        /// <summary>
        /// Indica l'esito generale della request.
        /// </summary>
        [JsonPropertyName("result")]
        public ResponseResult Result { get; set; } = new();
    }
}