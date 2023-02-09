using MLPosteDeliveryExpress.Json.Converter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    public class Contents
    {
        /// <summary>
        /// Tipo di contenitore.
        /// </summary>
        [JsonPropertyName("containerType")]
        [JsonConverter(typeof(AnnotatedEnumConverter<ContainerType>))]
        public ContainerType ContainerType { get; set; } = ContainerType.PackageOrPallet;

        /// <summary>
        /// Descrizione contenitore.
        /// </summary>
        [MaxLength(40)]
        [JsonPropertyName("tipocontText")]
        public string ContainerTypeDescription { get; set; } = "";

        /// <summary>
        /// Quantità.
        /// </summary>
        [JsonPropertyName("quantity")]
        public uint? Quantity { get; set; } = null;

        /// <summary>
        /// Peso espresso in kilogrammi.
        /// </summary>
        [JsonPropertyName("weight")]
        [JsonConverter(typeof(Decimal3Digits))]
        public decimal? Weight { get; set; } = null;

        /// <summary>
        /// Altezza espressa in centimetri.
        /// </summary>
        [JsonPropertyName("height")]
        [JsonConverter(typeof(Decimal3Digits))]
        public decimal? Height { get; set; } = null;

        /// <summary>
        /// Profondità espressa in centimetri.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonConverter(typeof(Decimal3Digits))]
        public decimal? Width { get; set; } = null;

        /// <summary>
        /// Lunghezza espressa in centimetri
        /// </summary>
        [JsonPropertyName("length")]
        [JsonConverter(typeof(Decimal3Digits))]
        public decimal? Length { get; set; } = null;
    }
}