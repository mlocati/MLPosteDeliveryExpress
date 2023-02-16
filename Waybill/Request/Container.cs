using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class Container
    {
        /// <summary>
        /// Codice del centro di costo.
        /// </summary>
        [JsonPropertyName("costCenterCode")]
        [MaxLength(20)]
        public string CostCenterCode { get; set; } = "";

        /// <summary>
        /// Se true non viene restituita la stampa della lettera di vettura.
        /// </summary>
        [JsonPropertyName("paperless")]
        public bool? Paperless { get; set; } = null;

        /// <summary>
        /// Data della spedizione.
        /// </summary>
        [JsonPropertyName("shipmentDate")]
        [JsonConverter(typeof(DateTimeISO8601))]
        public DateTime ShipmentDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Identificativo del partner che effettua la spedizione per conto del cliente.
        /// </summary>
        [JsonPropertyName("partnerId")]
        [MaxLength(20)]
        public string? PartnerId { get; set; } = null;

        /// <summary>
        /// Elenco di informazioni per cui si richiede la creazione della lettera di vettura.
        /// Le LdV negli elenchi sono in relazione tra loro, es. Andata & Ritorno.
        /// Per le lettere di vettura standard si avrà un solo oggetto nell'elenco.
        /// </summary>
        [JsonPropertyName("waybills")]
        public IList<Waybill> Waybills = new List<Waybill>();
    }
}