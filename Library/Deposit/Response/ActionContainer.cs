using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class ActionContainer
    {
        /// <summary>
        /// Descrizione azione di svincolo:
        /// - Torna In Consegna
        /// - Riconsegna ad altro indirizzo
        /// - Abbandono della spedizione
        /// - Ufficio Postale
        /// - Ritorno al Mittente
        /// - Fermo Deposito
        /// - Punto Poste - Locker
        /// - Punto Poste
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("result")]
        public ActionResultItem Result { get; set; } = new();
    }
}