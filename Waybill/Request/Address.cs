using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class Address
    {
        /// <summary>
        /// CAP.
        /// Se il country è ITA1 viene controllato che il CAP sia di 5 caratteri numerici interi.
        /// </summary>
        [MaxLength(7)]
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; } = "";

        /// <summary>
        /// Id Geopost.
        /// </summary>
        [JsonPropertyName("addressId")]
        public string? AddressId { get; set; } = null;

        /// <summary>
        /// Numero civico.
        /// </summary>
        [MaxLength(4)]
        [JsonPropertyName("streetNumber")]
        public string? StreetNumber { get; set; } = null;

        /// <summary>
        /// Città.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("city")]
        public string City { get; set; } = "";

        /// <summary>
        /// Indirizzo.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("address")]
        public string Street { get; set; } = "";

        /// <summary>
        /// Codice nazione ISO 4.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z][A-Z][1-9]$")]
        [JsonPropertyName("country")]
        public string CountryISO4 { get; set; } = "";

        /// <summary>
        /// Nome della nazione.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; } = "";

        /// <summary>
        /// Nome e cognome.
        /// </summary>
        [MaxLength(35)]
        [JsonPropertyName("nameSurname")]
        public string FirstLastName { get; set; } = "";

        /// <summary>
        /// Nome del referente.
        /// Obbligatorio per spedizioni internazionali.
        /// </summary>
        [MaxLength(35)]
        [JsonPropertyName("contactName")]
        public string? ContactName { get; set; } = null;

        /// <summary>
        /// Provincia.
        /// Se è il ricevente, nel caso di spedizioni in USA o Canada conterrà obbligatoriamente la sigla dello stato di destino, es. CA per California.
        /// </summary>
        [MinLength(2)]
        [MaxLength(2)]
        [JsonPropertyName("province")]
        public string? StateOrProvince { get; set; } = null;

        /// <summary>
        /// Email.
        /// Obbligatorio per spedizioni internazionali.
        /// Viene controllato che si tratti di una mail valida.
        /// </summary>
        [MaxLength(50)]
        [EmailAddress()]
        [JsonPropertyName("email")]
        public string? Email { get; set; } = null;

        /// <summary>
        /// Telefono.
        /// Obbligatorio per spedizioni internazionali.
        /// Viene controllato che sia di al massimo di 15 caratteri numerici ed eventuale + in testa.
        /// </summary>
        [RegularExpression(@"^\+?[0-9]{1,15}$")]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; } = null;

        /// <summary>
        /// Cellulare.
        /// Se presente il campo, viene controllato che sia di al massimo di 15 caratteri numerici ed eventuale + in testa.
        /// </summary>
        [RegularExpression(@"^\+?[0-9]{1,15}$")]
        [JsonPropertyName("cellphone")]
        public string? MobilePhone { get; set; } = null;

        /// <summary>
        /// Campo a disposizione dell'utente.
        /// Nel caso del mittente: sono le uniche note che vengono stampate.
        /// Nel caso del destinatario: non vengono stampate, utilizzare Notes del mittente.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("note1")]
        public string? Notes1 { get; set; } = null;

        /// <summary>
        /// Campo a disposizione dell'utente.
        /// Non vengono stampate, utilizzare Notes del mittente.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("note2")]
        public string? Notes2 { get; set; } = null;
    }
}