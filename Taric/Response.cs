using MLPosteDeliveryExpress.Service;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Taric
{
    public class Response : ResponseContainer
    {
        /// <summary>
        /// Elenco di oggetti contenenti i dati dei taric.
        /// </summary>
        [JsonPropertyName("taric")]
        public IList<Taric> Tarics { get; set; } = new List<Taric>();
    }
}