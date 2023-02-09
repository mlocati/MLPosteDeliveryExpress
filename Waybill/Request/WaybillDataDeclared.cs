using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class WaybillDataDeclared
    {
        /// <summary>
        /// Espresso in grammi. Viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("weight")]
        public uint Weight { get; set; } = 0;

        /// <summary>
        /// Espressa in centimetri. Viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("height")]
        public uint Height { get; set; } = 0;

        /// <summary>
        /// Espressa in centimetri. Viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("length")]
        public uint Length { get; set; } = 0;

        /// <summary>
        /// Espressa in centimetri. Viene controllato che sia un numero intero maggiore di 0 (non previse cifre decimali).
        /// </summary>
        [JsonPropertyName("width")]
        public uint Width { get; set; } = 0;

        /// <summary>
        /// Descrizione del contenuto della spedizione inserito a mano dall'utente, campo libero.
        /// Obbligatorio per spedizioni internazionali.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("description")]
        public string? Description { get; set; } = null;

        /// <summary>
        /// Codice identificativo del tipo di contenuto.
        /// Obbligatorio per il prodotto internazionale APT000903.
        /// </summary>
        [JsonPropertyName("contentCode")]
        public string? ContentCode { get; set; } = null;

        /// <summary>
        /// Codice dell'imballaggio.
        /// Obbligatorio per spedizioni internazionali
        /// </summary>
        [JsonPropertyName("packagingCode")]
        public string? PackagingCode { get; set; } = null;

        /// <summary>
        /// Array di oggetti json i dati degli eventuali articoli.
        /// Obbligatorio solo per internazionale standard sia UE che EUE.
        /// </summary>
        [JsonPropertyName("items")]
        public IList<WaybillDataDeclaredItem>? Items { get; set; } = null;

        /// <summary>
        /// Nazionalità ISO 2.
        /// Obbligatorio per prodotto internazionale APT000903.
        /// Se presente, viene controllato che sia una stringa contenente 2 caratteri.
        /// </summary>
        [MinLength(2)]
        [MaxLength(2)]
        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; } = null;
    }
}