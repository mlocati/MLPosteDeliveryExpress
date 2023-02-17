using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Country
{
    public class Country
    {
        public static readonly Lazy<Country> Italy = new(() => new Country()
        {
            ISO4 = "ITA1",
            ISO2 = "IT",
            Active = true,
            ItalianName = "Italia",
            EnglishName = "Italy",
        });

        /// <summary>
        /// Codice ISO4 della nazione.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z][A-Z][1-9]$")]
        [JsonPropertyName("iso4")]
        public string ISO4 { get; set; } = "";

        /// <summary>
        /// Codice ISO2 della nazione.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z]$")]
        [JsonPropertyName("iso2")]
        public string ISO2 { get; set; } = "";

        /// <summary>
        /// Indica se la nazione è attuva oppure no.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; } = false;

        /// <summary>
        /// Nome della nazione in italiano.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("name")]
        public string ItalianName { get; set; } = "";

        /// <summary>
        /// Nome della nazione in inglese.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("intName")]
        public string EnglishName { get; set; } = "";

        /// <summary>
        /// Se true si tratta di un paese al di fuori della comunità europea.
        /// </summary>
        [JsonPropertyName("extraue")]
        public bool ExtraUE { get; set; } = false;

        /// <summary>
        /// Elenco degli eventuali stati e relativa sigla (presente ad esempio per USA e Canada).
        /// </summary>
        [JsonPropertyName("states")]
        public IList<State>? States { get; set; } = null;

        /// <summary>
        /// Eventuali notizie riguardanti il paese.
        /// </summary>
        [JsonPropertyName("news")]
        public string? News { get; set; } = null;

        /// <summary>
        /// Elenco dei codici prodotto ammessi nella nazione.
        /// Valori posssibili APT000903, APT000904, APT000962 e APT000971.
        /// </summary>

        [JsonPropertyName("products")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumIListConverter<AptusCode>))]
        public IList<AptusCode>? Products { get; set; } = null;
    }
}