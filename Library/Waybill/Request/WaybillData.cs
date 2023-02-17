using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    public class WaybillData
    {
        /// <summary>
        /// Lista dei pesi e dimensioni dichiarati per i singoli colli.
        /// </summary>
        [JsonPropertyName("declared")]
        public IList<WaybillDataDeclared> Declared { get; set; } = new List<WaybillDataDeclared>();

        /// <summary>
        /// Oggetto presente solo per gli internazionali contenente le informazioni di base della spedizione.
        /// </summary>
        [JsonPropertyName("international")]
        public WaybillDataInternational? International { get; set; } = null;

        /// <summary>
        /// Contenuto della spedizione nazionale (campo libero).
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("content")]
        public string? Content { get; set; } = null;

        /// <summary>
        /// Può essere vuoto ({}).
        /// È costituito da una serie di oggetti chiave valore in cui la chiave è il codice Servizio Accessorio.
        /// Ad esempio:
        /// "services": {
        ///     "APT000918":{
        ///         "amount": "100";
        ///         "paymentMode": "ABM"
        ///     }
        /// }
        /// Per il dettaglio di come valorizzare i singoli servizi accessori e i controlli da prevedere vedere il file
        /// "Esempi Compilazione Codici Accessori.xlsx"
        /// </summary>
        [JsonPropertyName("services")]
        public WaybillDataServices Services { get; set; } = new();

        /// <summary>
        /// Oggetto contenete le informazioni del mittente.
        /// </summary>
        [JsonPropertyName("sender")]
        public Address Sender { get; set; } = new();

        /// <summary>
        /// Oggetto contenete le informazioni del destinatario.
        /// </summary>
        [JsonPropertyName("receiver")]
        public Address Receiver { get; set; } = new();
    }
}