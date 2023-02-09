using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    public class Pickup
    {
        /// <summary>
        /// Identifica il tipo di operazione.
        /// </summary>
        [JsonPropertyName("operation")]
        [JsonConverter(typeof(AnnotatedEnumConverter<Operation>))]
        public Operation Operation { get; set; } = Operation.Insert;

        /// <summary>
        /// Indica le tipologie di ritiro.
        /// </summary>
        [JsonPropertyName("bookingType")]
        [JsonConverter(typeof(AnnotatedEnumConverter<BookingType>))]
        public BookingType BookingType { get; set; } = BookingType.Single;

        /// <summary>
        /// Da non valorizzare.
        /// </summary>
        [MaxLength(20)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("bookingId")]
        public string Reserved1 { get; set; } = "";

        /// <summary>
        /// Valorizzare con il pickupId da eliminare.
        /// Obbligatorio se Operation è Cancel o Edit.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("pickupId")]
        public string PickupID { get; set; } = "";

        /// <summary>
        /// Valorizzare con il codice LdV.
        /// Obbligatorio se BookingType è Single o Paperless.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("shipmentId")]
        public string ShipmentId { get; set; } = "";

        /// <summary>
        /// Da non valorizzare.
        /// </summary>
        [MaxLength(50)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("customerShipmentId")]
        public string Reserved2 { get; set; } = "";

        /// <summary>
        /// Dettagli sul mittente.
        /// </summary>
        [JsonPropertyName("sender")]
        public ResultContainer Sender { get; set; } = new();

        /// <summary>
        /// Dettagli sul referente del ritiro.
        /// </summary>
        [JsonPropertyName("where")]
        public ResultContainer Where { get; set; } = new();

        /// <summary>
        /// Dettagli sul ricevente.
        /// </summary>
        [JsonPropertyName("receiver")]
        public ResultContainer Receiver { get; set; } = new();

        /// <summary>
        /// Dettagli sul contenuto.
        /// </summary>
        [JsonPropertyName("content")]
        public ContentsContainer Contents { get; set; } = new();

        /// <summary>
        /// È voluminoso?
        /// </summary>
        [JsonPropertyName("bulky")]
        [JsonConverter(typeof(BooleanT))]
        public bool Bulky { get; set; } = false;

        /// <summary>
        /// Data di ritiro richiesta.
        /// </summary>
        [JsonPropertyName("pickupDate")]
        [JsonConverter(typeof(DateISO8601))]
        public DateOnly PickupDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        /// <summary>
        /// Fascia di ritiro.
        /// </summary>
        [JsonPropertyName("timeSlot")]
        [JsonConverter(typeof(AnnotatedEnumConverter<TimeSlot>))]
        public TimeSlot TimeSlot { get; set; } = TimeSlot.MorningOrAfternoon;

        /// <summary>
        /// Spazio a disposizione del cliente.
        /// </summary>
        [MaxLength(255)]
        [JsonPropertyName("note1")]
        public string Notes1 { get; set; } = "";

        /// <summary>
        /// Spazio a disposizione del cliente.
        /// </summary>
        [MaxLength(255)]
        [JsonPropertyName("note2")]
        public string Notes2 { get; set; } = "";

        /// <summary>
        /// Spazio a disposizione del cliente.
        /// </summary>
        [MaxLength(255)]
        [JsonPropertyName("note3")]
        public string Notes3 { get; set; } = "";

        /// <summary>
        /// Da non valorizzare.
        /// </summary>
        [MaxLength(255)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("contentImport")]
        public string Reserved3 { get; set; } = "";
    }
}