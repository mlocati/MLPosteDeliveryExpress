using MLPosteDeliveryExpress.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Waybill.Response
{
    public class Waybill : ResponseResult
    {
        /// <summary>
        /// Il codice della ldv.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("code")]
        public string? Code { get; set; } = null;

        /// <summary>
        /// L'eventuale codice LdV del vettore internazionale.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("internationalCode")]
        public string? InternationalCode { get; set; } = null;

        /// <summary>
        /// L'eventuale secondo codice internazionale.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("internationalCode2")]
        public string? InternationalCode2 { get; set; } = null;

        /// <summary>
        /// DEPRECATED
        /// SAS Token.
        /// Parametro da passare al servizio descritto insieme al filepath per il download del pdf.
        /// </summary>
        [Obsolete("Use DownloadURL")]
        [JsonPropertyName("referralId")]
        public string? ReferralId { get; set; } = null;

        /// <summary>
        /// DEPRECATED
        /// Path del pdf.
        /// Parametro da passare al servizio insieme al referralId per il download del pdf.
        /// </summary>
        [Obsolete("Use DownloadURL")]
        [JsonPropertyName("filepath")]
        public string? Filepath { get; set; } = null;

        /// <summary>
        /// URL che punta al file pdf.
        /// Contiene l'hostname, il SAS Token ed il filepath.
        /// </summary>
        [MaxLength(300)]
        [JsonPropertyName("downloadURL")]
        public string? DownloadURL { get; set; } = null;

        /// <summary>
        /// NEXT_RELEASE
        /// Url per il download del 2dcomm prodotto in caso di Reverse Paperless, in particolare in presenza dei seguenti accessori reverse:
        /// - "product_code": "APT000979", "product_name": "Reverse PuntoPoste"
        /// - "product_code": "APT000981", "product_name": "Reverse Ufficio Postale"
        /// Il link permette il download del 2dcomm in formato gif.
        /// Il link è del tutto simile a downloadURL, cambia solo l'estensione del file.
        /// </summary>
        /// <de
        [MaxLength(300)]
        [JsonPropertyName("downloadUrlImg")]
        public string? DownloadUrlImg { get; set; } = null;
    }
}