using MLPosteDeliveryExpress.Json.Converter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    public class Address
    {
        /// <summary>
        /// Nome del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("givenName")]
        public string FirstName { get; set; } = "";

        /// <summary>
        /// Cognome del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("surname")]
        public string LastName { get; set; } = "";

        /// <summary>
        /// Numero civico del mittente/referente ritiro ("where")/destinatario.
        /// Richiesto per il referente ritiro ("where").
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("streetNumber")]
        public string StreetNumber { get; set; } = "";

        /// <summary>
        /// Nome via del mittente/referente ritiro ("where")/destinatario.
        /// Richiesto per il referente ritiro ("where").
        /// </summary>
        [MaxLength(60)]
        [JsonPropertyName("streetName")]
        public string StreetName { get; set; } = "";

        /// <summary>
        /// Tipo via (via, viale, piazza) del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(60)]
        [JsonPropertyName("streetType")]
        public string StreetType { get; set; } = "";

        /// <summary>
        /// Piano del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("floor")]
        public string Floor { get; set; } = "";

        /// <summary>
        /// Città del mittente/referente ritiro ("where")/destinatario.
        /// Richiesto per il referente ritiro ("where").
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("town")]
        public string City { get; set; } = "";

        /// <summary>
        /// Provincia del mittente/referente ritiro ("where")/destinatario.
        /// Richiesto per il referente ritiro ("where").
        /// </summary>
        [MaxLength(3)]
        [JsonPropertyName("region")]
        public string StateOrProvince { get; set; } = "";

        /// <summary>
        /// Codice avviamento postale del mittente/referente ritiro ("where")/destinatario.
        /// Richiesto per il referente ritiro ("where").
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("postCode")]
        public string ZipCode { get; set; } = "";

        /// <summary>
        /// Nazione del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(3)]
        [JsonPropertyName("country")]
        public string Country { get; set; } = "";

        /// <summary>
        /// Indicazione km su strada del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("km")]
        public string Km { get; set; } = "";

        /// <summary>
        /// Palazzina del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("building")]
        public string Building { get; set; } = "";

        /// <summary>
        /// Scala del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("stairs")]
        public string Stairs { get; set; } = "";

        /// <summary>
        /// Ufficio/stanza del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("room")]
        public string Room { get; set; } = "";

        /// <summary>
        /// Interno del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("internal")]
        public string Internal { get; set; } = "";

        /// <summary>
        /// Interno del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [JsonPropertyName("reception")]
        [JsonConverter(typeof(BooleanT))]
        public bool Reception { get; set; } = false;

        /// <summary>
        /// Contatto telefonico del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = "";

        /// <summary>
        /// Email del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(241)]
        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        /// <summary>
        /// Nominativo citofono del mittente/referente ritiro ("where")/destinatario.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("nameIntercom")]
        public string IntercomName { get; set; } = "";
    }
}