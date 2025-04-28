using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DP = MLPosteDeliveryExpress.DeliveryPoint.Response;
using C = MLPosteDeliveryExpress.Country;

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
        public string Content { get; set; } = "";

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

        public void ApplyDeliveryPoint(DP.DeliveryPoint deliveryPoint)
        {
            bool useAddress = true;
            switch (deliveryPoint.ServiceType)
            {
                case DeliveryPoint.ServiceType.PuntoPosteLocker:
                    this.Services.Add(new MLPosteDeliveryExpress.Waybill.Services.DeliveryToLockerItaly(
                        deliveryPoint.OfficeCode,
                        deliveryPoint.OfficeDescription
                    ));
                    break;

                case DeliveryPoint.ServiceType.PuntoPoste:
                    this.Services.Add(new MLPosteDeliveryExpress.Waybill.Services.PuntoPoste(
                        deliveryPoint.OfficeCode,
                        deliveryPoint.OfficeDescription
                    ));
                    break;

                default:
                    throw new System.Exception("Unsupported delivery point type: " + deliveryPoint.ServiceType);
            }
            if (useAddress)
            {
                this.Receiver.Street = deliveryPoint.Address;
                this.Receiver.StreetNumber = "";
                this.Receiver.City = deliveryPoint.City;
                this.Receiver.StateOrProvince = deliveryPoint.Province;
                this.Receiver.ZipCode = deliveryPoint.ZipCode;
                this.Receiver.CountryISO4 = C.Country.Italy.Value.ISO4;
                this.Receiver.CountryName = C.Country.Italy.Value.EnglishName;
            }
        }
    }
}