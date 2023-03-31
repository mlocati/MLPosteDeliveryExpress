using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    public class Deposit
    {
        /// <summary>
        /// id LdV.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("shipmentId")]
        public string ShipmentID { get; set; } = "";

        /// <summary>
        /// id LdV internazionale.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("shipmentIdItz")]
        public string InternationalShipmentID { get; set; } = "";

        /// <summary>
        /// Riferimento spedizione cliente.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("customerShipmentId")]
        public string CustomerShipmentID { get; set; } = "";

        /// <summary>
        /// Identificativo dossier giacenza.
        /// </summary>
        [MaxLength(10)]
        [JsonPropertyName("depositDossier")]
        public string DepositDossierID { get; set; } = "";

        [JsonPropertyName("depositStatus")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Status>))]
        public Status? Status { get; set; } = null;

        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("depositStatusDescription")]
        public string StatusDescription { get; set; } = "";

        /// <summary>
        /// Destinatario.
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("receipt")]
        public string Recipient { get; set; } = "";

        /// <summary>
        /// Mittente.
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("sender")]
        public string Sender { get; set; } = "";

        /// <summary>
        /// Multicollo.
        /// </summary>
        [JsonPropertyName("multiplePackages")]
        [JsonConverter(typeof(Json.Converter.BooleanX))]
        public bool MultiPack { get; set; } = false;

        /// <summary>
        /// Numero colli.
        /// </summary>
        [JsonPropertyName("packagesNumber")]
        [JsonConverter(typeof(Json.Converter.UIntNullableAsString))]
        public uint? NumberOfPackages { get; set; } = null;

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("motivationId")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Reason>))]
        public Reason? Reason { get; set; } = null;

        [MaxLength(100)]
        [JsonPropertyName("motivationDescription")]
        public string ReasonDescription { get; set; } = "";

        /// <summary>
        /// Indica se la spedizione è svincolabile.
        /// </summary>
        [JsonPropertyName("releasable")]
        [JsonConverter(typeof(Json.Converter.BooleanAsSN))]
        public bool Releasable { get; set; } = false;

        /// <summary>
        /// Data di partenza della spedizione.
        /// </summary>
        [JsonPropertyName("shipmentStardDate")]
        [JsonConverter(typeof(Json.Converter.DateISO8601Nullable))]
        public DateOnly? ShipmentStartDate { get; set; } = null;

        /// <summary>
        /// Data di inizio giacenza.
        /// </summary>
        [JsonPropertyName("startDate")]
        [JsonConverter(typeof(Json.Converter.DateISO8601Nullable))]
        public DateOnly? StartDate { get; set; } = null;

        /// <summary>
        /// Data di fine giacenza.
        /// </summary>
        [JsonPropertyName("endDate")]
        [JsonConverter(typeof(Json.Converter.DateISO8601Nullable))]
        public DateOnly? EndDate { get; set; } = null;

        /// <summary>
        /// Identificativo centro di costo.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("cdc")]
        public string CostCenterCode { get; set; } = "";

        /// <summary>
        /// Denominazione prodotto.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("product")]
        public string Product { get; set; } = "";

        /// <summary>
        /// Azione di svincolo (se effettuata).
        /// </summary>
        [JsonPropertyName("releaseActionId")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumConverter<Action>))]
        public Action Action { get; set; } = Action.None;

        /// <summary>
        /// Descrizione azione di svincolo.
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("releaseActionDescription")]
        public string ActionDescription { get; set; } = "";
    }
}