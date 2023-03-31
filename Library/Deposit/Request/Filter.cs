using System;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    public class Filter
    {
        /// <summary>
        /// Identificativo Centro di costo.
        /// </summary>
        [JsonPropertyName("cdc")]
        public string CostCenterCode { get; set; } = "";

        /// <summary>
        /// Data di inizio giacenza.
        /// </summary>
        [JsonPropertyName("depositDateFrom")]
        [JsonConverter(typeof(Json.Converter.DateISO8601NoSep))]
        public DateOnly? DepisitDateFrom { get; set; } = null;

        /// <summary>
        /// Data di fine giacenza.
        /// </summary>
        [JsonPropertyName("depositDateTo")]
        [JsonConverter(typeof(Json.Converter.DateISO8601NoSep))]
        public DateOnly? DepisitDateTo { get; set; } = null;

        /// <summary>
        /// Data di accettazione LdV da.
        /// </summary>
        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(Json.Converter.DateISO8601NoSep))]
        public DateOnly? DateFrom { get; set; } = null;

        /// <summary>
        /// Data di accettazione LdV a.
        /// </summary>
        [JsonPropertyName("dateTo")]
        [JsonConverter(typeof(Json.Converter.DateISO8601NoSep))]
        public DateOnly? DateTo { get; set; } = null;

        [JsonPropertyName("status")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Reason>))]
        public Deposit.Reason? Status { get; set; } = null;

        [JsonPropertyName("depositReason")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Status>))]
        public Deposit.Status? Reason { get; set; } = null;
    }
}