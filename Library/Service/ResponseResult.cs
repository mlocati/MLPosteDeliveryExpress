using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Service
{
    public class ResponseResult
    {
        /// <summary>
        /// Non sono i codici di errore http.
        /// 0 ok (staus 200), >=1 sono errori.
        /// </summary>
        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; } = 0;

        /// <summary>
        /// Il messaggio di errore legato al codice.
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; set; } = "";
    }
}