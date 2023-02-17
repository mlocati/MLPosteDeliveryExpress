using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class WaybillDataDeclaredItem
    {
        /// <summary>
        /// Numero progressivo dell'articolo.
        /// Se presenti gli articoli, viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali)
        /// </summary>
        [JsonPropertyName("itemNumber")]
        public uint ItemNumber { get; set; } = 0;

        /// <summary>
        /// Codice taric.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("taric")]
        public string Taric { get; set; } = "";

        /// <summary>
        /// Valore totale dell'articolo in centesimi in euro.
        /// Se presenti gli articoli, viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("totalValue")]
        public uint TotalValue { get; set; } = 0;

        /// <summary>
        /// Quantità articolo.
        /// Se presenti gli articoli, viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("quantity")]
        public uint Quantity { get; set; } = 0;

        /// <summary>
        /// Peso totale dell'articolo espresso in grammi.
        /// Se presenti gli articoli, viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("totalWeight")]
        public uint TotalWeight { get; set; } = 0;

        /// <summary>
        /// Paese di origine ISO2.
        /// Se presenti gli articoli, viene controllato un controllo che il codice ISO2 sia una stringa contenente 2 caratteri.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z]$")]
        [JsonPropertyName("originCountry")]
        public string OriginCountryISO2 { get; set; } = "";
    }
}