using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    public class Filter
    {
        /// <summary>
        /// Indica le tipologie di ritiro.
        /// </summary>
        [JsonPropertyName("bookingType")]
        [JsonConverter(typeof(AnnotatedEnumConverter<BookingType>))]
        public BookingType? BookingType { get; set; } = null;

        /// <summary>
        /// Codice prenotazione ritiro.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("bookingId")]
        public string BookingID { get; set; } = "";

        /// <summary>
        /// Codice prenotazione pickup.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("pickupId")]
        public string PickupID { get; set; } = "";

        /// <summary>
        /// LdV
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("shipmentId")]
        public string ShipmentID { get; set; } = "";

        /// <summary>
        /// Riferimento spedizione cliente.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("customerShipmentId")]
        public string CustomerShipmentID { get; set; } = "";

        /// <summary>
        /// Data iniziale di estrazione ritiri.
        /// </summary>
        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateISO8601))]
        public DateOnly DateFrom { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        /// <summary>
        /// Data finale di estrazione ritiri.
        /// </summary>
        [JsonPropertyName("dateTo")]
        [JsonConverter(typeof(DateISO8601))]
        public DateOnly? DateTo { get; set; } = null;
    }
}