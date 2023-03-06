using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    public class FoundPickup
    {
        private static readonly Lazy<TimeZoneInfo?> ItalyTZ = new(() =>
        {
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Rome");
                return tz == TimeZoneInfo.Local ? null : tz;
            }
            catch (TimeZoneNotFoundException)
            {
                return null;
            }
        });

        /// <summary>
        /// Canale di richiesta ritiro.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = "";

        /// <summary>
        /// Codice prenotazione ritiro.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("bookingCode")]
        public string BookingCode { get; set; } = "";

        /// <summary>
        /// Indirizzo di pickup.
        /// </summary>
        [MaxLength(255)]
        [JsonPropertyName("pickupAddress")]
        public string PickupAddress { get; set; } = "";

        /// <summary>
        /// Orario di inserimento pickup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [JsonPropertyName("insertTime")]
        [JsonConverter(typeof(TimeHHMMSSNullable))]
        public TimeOnly? InsertTime { get; set; } = null;

        /// <summary>
        /// Data di inserimento pickup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [JsonPropertyName("insertDate")]
        [JsonConverter(typeof(DateISO8601Nullable))]
        public DateOnly? InsertDate { get; set; } = null;

        [JsonIgnore]
        public DateTime? InsertDateTime
        {
            get => ToDateTime(this.InsertDate, this.InsertTime);
            set => (this.InsertDate, this.InsertTime) = FromDateTime(value);
        }

        [JsonPropertyName("isEditable")]
        [JsonConverter(typeof(Boolean1))]
        public bool IsEditable { get; set; } = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [JsonPropertyName("modifyTime")]
        [JsonConverter(typeof(TimeHHMMSSNullable))]
        public TimeOnly? ModifyTime { get; set; } = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [JsonPropertyName("modifyDate")]
        [JsonConverter(typeof(DateISO8601Nullable))]
        public DateOnly? ModifyDate { get; set; } = null;

        [JsonIgnore]
        public DateTime? ModifyDateTime
        {
            get => ToDateTime(this.ModifyDate, this.ModifyTime);
            set => (this.ModifyDate, this.ModifyTime) = FromDateTime(value);
        }

        [JsonPropertyName("statusDescription")]
        public string StatusDescription { get; set; } = "";

        [JsonPropertyName("status")]
        [JsonConverter(typeof(AnnotatedEnumConverter<Status>))]
        public Status? Status { get; set; } = null;

        [JsonPropertyName("timeSlot")]
        [JsonConverter(typeof(AnnotatedEnumConverter<TimeSlot>))]
        public TimeSlot TimeSlot { get; set; } = TimeSlot.MorningOrAfternoon;

        [JsonPropertyName("pickupDate")]
        [JsonConverter(typeof(DateISO8601))]
        public DateOnly? PickupDate { get; set; } = null;

        [JsonPropertyName("customerShipmentId")]
        public string CustomerShipmentID { get; set; } = "";

        [JsonPropertyName("shipmentId")]
        public string ShipmentID { get; set; } = "";

        [JsonPropertyName("bookingType")]
        [JsonConverter(typeof(AnnotatedEnumConverter<BookingType>))]
        public BookingType BookingType { get; set; } = BookingType.Single;

        [JsonPropertyName("bookingId")]
        public string BookingID { get; set; } = "";

        [JsonPropertyName("pickupId")]
        public string PickupID { get; set; } = "";

        private static DateTime? ToDateTime(DateOnly? date, TimeOnly? time)
        {
            if (date == null || time == null)
            {
                return null;
            }
            var tz = ItalyTZ.Value;
            if (tz == null)
            {
                return date.Value.ToDateTime(time.Value);
            }
            var dateTime = date.Value.ToDateTime(time.Value, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTime(dateTime, tz, TimeZoneInfo.Local);
        }

        private static (DateOnly?, TimeOnly?) FromDateTime(DateTime? value)
        {
            if (value == null)
            {
                return (null, null);
            }
            var dateTime = value.Value;
            var tz = ItalyTZ.Value;
            if (tz != null)
            {
                dateTime = TimeZoneInfo.ConvertTime(dateTime, tz);
            }
            return (DateOnly.FromDateTime(dateTime), TimeOnly.FromDateTime(dateTime));
        }
    }
}