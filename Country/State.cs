using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Country
{
    public class State
    {
        /// <summary>
        /// Sigla dello stato.
        /// </summary>
        [MaxLength(4)]
        [JsonPropertyName("state_code")]
        public string Code { get; set; } = "";

        /// <summary>
        /// Nome dello stato.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("state_name")]
        public string Name { get; set; } = "";
    }
}