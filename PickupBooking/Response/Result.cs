using MLPosteDeliveryExpress.Json.Converter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Response
{
    internal class Result
    {
        /// <summary>
        /// OK/KO.
        /// </summary>
        [JsonPropertyName("result")]
        [JsonConverter(typeof(BooleanOkKo))]
        public bool Success { get; set; } = false;

        /// <summary>
        /// E0013 => PICKUP data is mandatory
        /// E0014 => BOOKING_TYPE is incorrect - RIT0001 RIT0002 RIT0003
        /// E0015 => For BOOKING_TYPE=RIT0002 SHIPMENT_ID is mandatory
        /// E0016 => there is already a pickup for the same shipment
        /// E0017 => CONTAINER_TYPE is incorrect
        /// E0024 => Mandatory address data
        /// E0028 => OPERATION is incorrect. Correct value is I
        /// E0029 => there is already a pickup for the same data
        /// E0030 => SHIPMENT_ID incorrect
        /// E0031 => SHIPMENT_ID incorrect
        /// E0033 => Cancellation not possible
        /// E0034 => SHIPMENT_ID incorrect
        /// E0035 => Time slot not compatible with today's date
        /// E0036 => SHIPMENT_ID incorrect
        /// E0037 => SHIPMENT_ID accepted. Pickup booking not possible
        /// E0038 => PICKUP_DATE is mandatory in the future
        /// E0039 => there is already a pickup for the same shipment
        /// E0999 => Generic error
        /// </summary>
        [MaxLength(6)]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; } = "";

        [MaxLength(50)]
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; set; } = "";
    }
}