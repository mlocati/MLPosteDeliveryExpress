using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Taric
{
    public class Taric
    {
        /// <summary>
        /// Codice del taric.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("taric_code")]
        public string Code { get; set; } = "";

        /// <summary>
        /// Descrizione in italiano.
        /// </summary>
        [MaxLength(300)]
        [JsonPropertyName("italian_description")]
        public string ItalianDescription { get; set; } = "";

        /// <summary>
        /// Descrizione in inglese.
        /// </summary>
        [MaxLength(300)]
        [JsonPropertyName("english_description")]
        public string EnglishDescription { get; set; } = "";
    }
}