using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class Address : ICloneable
    {
        /// <summary>
        /// Nome del referente.
        /// Obbligatorio per spedizioni internazionali.
        /// </summary>
        [MaxLength(35)]
        [JsonPropertyName("contactName")]
        [DisplayName("Contact Name")]
        public string? ContactName { get; set; } = null;

        /// <summary>
        /// Nome e cognome.
        /// </summary>
        [MaxLength(35)]
        [JsonPropertyName("nameSurname")]
        [DisplayName("First and Last Name")]
        public string FirstLastName { get; set; } = "";

        /// <summary>
        /// Indirizzo.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("address")]
        [DisplayName("Street")]
        public string Street { get; set; } = "";

        /// <summary>
        /// Numero civico.
        /// </summary>
        [MaxLength(4)]
        [JsonPropertyName("streetNumber")]
        [DisplayName("Street Number")]
        public string? StreetNumber { get; set; } = null;

        /// <summary>
        /// CAP.
        /// Se il country è ITA1 viene controllato che il CAP sia di 5 caratteri numerici interi.
        /// </summary>
        [MaxLength(7)]
        [JsonPropertyName("zipCode")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = "";

        /// <summary>
        /// Città.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("city")]
        [DisplayName("City")]
        public string City { get; set; } = "";

        /// <summary>
        /// Provincia.
        /// Se è il ricevente, nel caso di spedizioni in USA o Canada conterrà obbligatoriamente la sigla dello stato di destino, es. CA per California.
        /// </summary>
        [MinLength(2)]
        [MaxLength(2)]
        [JsonPropertyName("province")]
        [DisplayName("State/Province")]
        public string? StateOrProvince { get; set; } = null;

        /// <summary>
        /// Codice nazione ISO 4.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z][A-Z][1-9]$")]
        [JsonPropertyName("country")]
        [DisplayName("Country Code (ISO4)")]
        public string CountryISO4 { get; set; } = "";

        /// <summary>
        /// Nome della nazione.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("countryName")]
        [DisplayName("Country Name")]
        public string CountryName { get; set; } = "";

        /// <summary>
        /// Email.
        /// Obbligatorio per spedizioni internazionali.
        /// Viene controllato che si tratti di una mail valida.
        /// </summary>
        [MaxLength(50)]
        [EmailAddress()]
        [JsonPropertyName("email")]
        [DisplayName("Email")]
        public string? Email { get; set; } = null;

        /// <summary>
        /// Telefono.
        /// Obbligatorio per spedizioni internazionali.
        /// Viene controllato che sia di al massimo di 15 caratteri numerici ed eventuale + in testa.
        /// </summary>
        [RegularExpression(@"^\+?[0-9]{1,15}$")]
        [JsonPropertyName("phone")]
        [DisplayName("Phone")]
        public string? Phone { get; set; } = null;

        /// <summary>
        /// Cellulare.
        /// Se presente il campo, viene controllato che sia di al massimo di 15 caratteri numerici ed eventuale + in testa.
        /// </summary>
        [RegularExpression(@"^\+?[0-9]{1,15}$")]
        [JsonPropertyName("cellphone")]
        [DisplayName("Mobile phone")]
        public string? MobilePhone { get; set; } = null;

        /// <summary>
        /// Id Geopost.
        /// </summary>
        [JsonPropertyName("addressId")]
        [DisplayName("ID Geopost")]
        public string? AddressId { get; set; } = null;

        /// <summary>
        /// Campo a disposizione dell'utente.
        /// Nel caso del mittente: sono le uniche note che vengono stampate.
        /// Nel caso del destinatario: non vengono stampate, utilizzare Notes del mittente.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("note1")]
        [DisplayName("Notes (1)")]
        public string? Notes1 { get; set; } = null;

        /// <summary>
        /// Campo a disposizione dell'utente.
        /// Non vengono stampate, utilizzare Notes del mittente.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("note2")]
        [DisplayName("Notes (2)")]
        public string? Notes2 { get; set; } = null;

        public object Clone()
        {
            return new Address()
            {
                ContactName = this.ContactName,
                FirstLastName = this.FirstLastName,
                Street = this.Street,
                StreetNumber = this.StreetNumber,
                ZipCode = this.ZipCode,
                City = this.City,
                StateOrProvince = this.StateOrProvince,
                CountryISO4 = this.CountryISO4,
                CountryName = this.CountryName,
                Email = this.Email,
                Phone = this.Phone,
                MobilePhone = this.MobilePhone,
                AddressId = this.AddressId,
                Notes1 = this.Notes1,
                Notes2 = this.Notes2,
            };
        }
    }
}