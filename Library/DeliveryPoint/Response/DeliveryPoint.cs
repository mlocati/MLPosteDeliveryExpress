using System;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.DeliveryPoint.Response
{
    public class DeliveryPoint
    {
        [JsonPropertyName("officeCode")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string OfficeCode { get; set; } = "";

        [JsonPropertyName("officeDescription")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string OfficeDescription { get; set; } = "";

        [JsonPropertyName("address")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string Address { get; set; } = "";

        [JsonPropertyName("place")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string City { get; set; } = "";

        [JsonPropertyName("province")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string Province { get; set; } = "";

        [JsonPropertyName("zipCode")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string ZipCode { get; set; } = "";

        [JsonPropertyName("phone")]
        [JsonConverter(typeof(Json.Converter.TrimString))]
        public string Phone { get; set; } = "";

        [JsonPropertyName("openTimeMon")]
        [JsonConverter(typeof(Json.Converter.TimeHHMMSSNullable))]
        public TimeOnly? OpeningTimeWeekdays { get; set; } = null;

        [JsonPropertyName("closeTimeMon")]
        [JsonConverter(typeof(Json.Converter.TimeHHMMSSNullable))]
        public TimeOnly? ClosingTimeWeekdays { get; set; } = null;

        [JsonPropertyName("openTimeSat")]
        [JsonConverter(typeof(Json.Converter.TimeHHMMSSNullable))]
        public TimeOnly? OpeningTimeSaturdays { get; set; } = null;

        [JsonPropertyName("closeTimeSat")]
        [JsonConverter(typeof(Json.Converter.TimeHHMMSSNullable))]
        public TimeOnly? ClosingTimeSaturdays { get; set; } = null;

        [JsonPropertyName("saturationPercentage")]
        [JsonConverter(typeof(Json.Converter.UIntAsString))]
        public uint SaturationPercentage { get; set; } = 0;

        [JsonPropertyName("YDegree")]
        [JsonConverter(typeof(Json.Converter.DecimalAsString))]
        public decimal Latitude { get; set; } = 0M;

        [JsonPropertyName("XDegree")]
        [JsonConverter(typeof(Json.Converter.DecimalAsString))]
        public decimal Longitude { get; set; } = 0M;
    }
}