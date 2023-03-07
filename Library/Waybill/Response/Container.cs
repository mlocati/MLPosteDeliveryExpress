using MLPosteDeliveryExpress.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Response
{
    public class Container : ResponseContainer
    {
        /// <summary>
        /// Stesso valore passato in input.
        /// </summary>
        [MaxLength(20)]
        [JsonPropertyName("costCenterCode")]
        public string CostCenterCode { get; set; } = "";

        /// <summary>
        /// Stesso valore passato in input.
        /// </summary>
        [JsonPropertyName("Paperless")]
        public bool Paperless { get; set; } = false;

        /// <summary>
        /// Elenco dei codici oggetto della request.
        /// </summary>
        [JsonPropertyName("waybills")]
        public List<Waybill>? Waybills { get; set; } = null;
    }
}