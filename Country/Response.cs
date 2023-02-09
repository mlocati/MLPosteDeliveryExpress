using MLPosteDeliveryExpress.Service;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Country
{
    public class Response : ResponseContainer
    {
        /// <summary>
        /// Elenco di oggetti contenenti i dati delle nazioni.
        /// </summary>
        [JsonPropertyName("countries")]
        public IList<Country> Countries { get; set; } = new List<Country>();
    }
}