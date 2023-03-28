using MLPosteDeliveryExpress.Json.Converter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    internal class Return
    {
        [JsonPropertyName("messages")]
        public List<MessagesContainer> Messages { get; set; } = new();

        [JsonPropertyName("outcome")]
        [JsonConverter(typeof(BooleanOkKo))]
        public bool Outcome { get; set; } = false;

        /// <summary>
        /// Codice identificativo dell'esito
        /// 0 = OK
        /// 100 - 199 = Errore formale
        /// 200 - 299 = Errore di business
        /// 999 = Errore generico
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; } = -1;

        [JsonPropertyName("result")]
        [JsonConverter(typeof(BooleanOkKo))]
        public bool Result { get; set; } = false;

        [JsonPropertyName("shipment")]
        public List<Shipment> Shipment { get; set; } = new();
    }
}