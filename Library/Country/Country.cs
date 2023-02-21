using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Country
{
    public class Country
    {
        public static readonly Lazy<Country> Italy = new(() => new Country()
        {
            ISO4 = "ITA1",
            ISO2 = "IT",
            Active = true,
            ItalianName = "Italia",
            EnglishName = "Italy",
            States = new List<State>()
            {
                new() { Code = "AG", Name = "Agrigento"},
                new() { Code = "AL", Name = "Alessandria"},
                new() { Code = "AN", Name = "Ancona"},
                new() { Code = "AR", Name = "Arezzo"},
                new() { Code = "AP", Name = "Ascoli Piceno"},
                new() { Code = "AT", Name = "Asti"},
                new() { Code = "AV", Name = "Avellino"},
                new() { Code = "BA", Name = "Bari"},
                new() { Code = "BT", Name = "Barletta-Andria-Trani"},
                new() { Code = "BL", Name = "Belluno"},
                new() { Code = "BN", Name = "Benevento"},
                new() { Code = "BG", Name = "Bergamo"},
                new() { Code = "BI", Name = "Biella"},
                new() { Code = "BO", Name = "Bologna"},
                new() { Code = "BZ", Name = "Bolzano"},
                new() { Code = "BS", Name = "Brescia"},
                new() { Code = "BR", Name = "Brindisi"},
                new() { Code = "CA", Name = "Cagliari"},
                new() { Code = "CL", Name = "Caltanissetta"},
                new() { Code = "CB", Name = "Campobasso"},
                new() { Code = "CE", Name = "Caserta"},
                new() { Code = "CT", Name = "Catania"},
                new() { Code = "CZ", Name = "Catanzaro"},
                new() { Code = "CH", Name = "Chieti"},
                new() { Code = "CO", Name = "Como"},
                new() { Code = "CS", Name = "Cosenza"},
                new() { Code = "CR", Name = "Cremona"},
                new() { Code = "KR", Name = "Crotone"},
                new() { Code = "CN", Name = "Cuneo"},
                new() { Code = "FM", Name = "Fermo"},
                new() { Code = "FE", Name = "Ferrara"},
                new() { Code = "FI", Name = "Firenze"},
                new() { Code = "FG", Name = "Foggia"},
                new() { Code = "FC", Name = "Forlì-Cesena"},
                new() { Code = "FR", Name = "Frosinone"},
                new() { Code = "GE", Name = "Genova"},
                new() { Code = "GO", Name = "Gorizia"},
                new() { Code = "GR", Name = "Grosseto"},
                new() { Code = "IM", Name = "Imperia"},
                new() { Code = "IS", Name = "Isernia"},
                new() { Code = "SU", Name = "Sud Sardegna"},
                new() { Code = "TS", Name = "Trieste"},
                new() { Code = "AQ", Name = "L'Aquila"},
                new() { Code = "SP", Name = "La Spezia"},
                new() { Code = "LT", Name = "Latina"},
                new() { Code = "LE", Name = "Lecce"},
                new() { Code = "LC", Name = "Lecco"},
                new() { Code = "LI", Name = "Livorno"},
                new() { Code = "LO", Name = "Lodi"},
                new() { Code = "LU", Name = "Lucca"},
                new() { Code = "MC", Name = "Macerata"},
                new() { Code = "MN", Name = "Mantova"},
                new() { Code = "MS", Name = "Massa-Carrara"},
                new() { Code = "MT", Name = "Matera"},
                new() { Code = "ME", Name = "Messina"},
                new() { Code = "MI", Name = "Milano"},
                new() { Code = "MO", Name = "Modena"},
                new() { Code = "MB", Name = "Monza e Brianza"},
                new() { Code = "NA", Name = "Napoli"},
                new() { Code = "NO", Name = "Novara"},
                new() { Code = "NU", Name = "Nuoro"},
                new() { Code = "OR", Name = "Oristano"},
                new() { Code = "PD", Name = "Padova"},
                new() { Code = "PA", Name = "Palermo"},
                new() { Code = "PR", Name = "Parma"},
                new() { Code = "PV", Name = "Pavia"},
                new() { Code = "PG", Name = "Perugia"},
                new() { Code = "PU", Name = "Pesaro e Urbino"},
                new() { Code = "PE", Name = "Pescara"},
                new() { Code = "PC", Name = "Piacenza"},
                new() { Code = "PI", Name = "Pisa"},
                new() { Code = "PT", Name = "Pistoia"},
                new() { Code = "PN", Name = "Pordenone"},
                new() { Code = "PZ", Name = "Potenza"},
                new() { Code = "PO", Name = "Prato"},
                new() { Code = "EN", Name = "Enna"},
                new() { Code = "VA", Name = "Varese"},
                new() { Code = "RG", Name = "Ragusa"},
                new() { Code = "RA", Name = "Ravenna"},
                new() { Code = "RC", Name = "Reggio Calabria"},
                new() { Code = "RE", Name = "Reggio Emilia"},
                new() { Code = "RI", Name = "Rieti"},
                new() { Code = "RN", Name = "Rimini"},
                new() { Code = "RM", Name = "Roma"},
                new() { Code = "RO", Name = "Rovigo"},
                new() { Code = "SA", Name = "Salerno"},
                new() { Code = "SS", Name = "Sassari"},
                new() { Code = "SV", Name = "Savona"},
                new() { Code = "SI", Name = "Siena"},
                new() { Code = "SR", Name = "Siracusa"},
                new() { Code = "SO", Name = "Sondrio"},
                new() { Code = "TA", Name = "Taranto"},
                new() { Code = "TE", Name = "Teramo"},
                new() { Code = "TR", Name = "Terni"},
                new() { Code = "TO", Name = "Torino"},
                new() { Code = "TP", Name = "Trapani"},
                new() { Code = "TN", Name = "Trento"},
                new() { Code = "TV", Name = "Treviso"},
                new() { Code = "UD", Name = "Udine"},
                new() { Code = "AO", Name = "Aosta"},
                new() { Code = "VE", Name = "Venezia"},
                new() { Code = "VB", Name = "Verbano-Cusio-Ossola"},
                new() { Code = "VC", Name = "Vercelli"},
                new() { Code = "VR", Name = "Verona"},
                new() { Code = "VV", Name = "Vibo Valentia"},
                new() { Code = "VI", Name = "Vicenza"},
                new() { Code = "VT", Name = "Viterbo"},
            }
        });

        /// <summary>
        /// Codice ISO4 della nazione.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z][A-Z][1-9]$")]
        [JsonPropertyName("iso4")]
        public string ISO4 { get; set; } = "";

        /// <summary>
        /// Codice ISO2 della nazione.
        /// </summary>
        [RegularExpression("^[A-Z][A-Z]$")]
        [JsonPropertyName("iso2")]
        public string ISO2 { get; set; } = "";

        /// <summary>
        /// Indica se la nazione è attuva oppure no.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; } = false;

        /// <summary>
        /// Nome della nazione in italiano.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("name")]
        public string ItalianName { get; set; } = "";

        /// <summary>
        /// Nome della nazione in inglese.
        /// </summary>
        [MaxLength(30)]
        [JsonPropertyName("intName")]
        public string EnglishName { get; set; } = "";

        /// <summary>
        /// Se true si tratta di un paese al di fuori della comunità europea.
        /// </summary>
        [JsonPropertyName("extraue")]
        public bool ExtraUE { get; set; } = false;

        /// <summary>
        /// Elenco degli eventuali stati e relativa sigla (presente ad esempio per USA e Canada).
        /// </summary>
        [JsonPropertyName("states")]
        public IList<State>? States { get; set; } = null;

        /// <summary>
        /// Eventuali notizie riguardanti il paese.
        /// </summary>
        [JsonPropertyName("news")]
        public string? News { get; set; } = null;

        /// <summary>
        /// Elenco dei codici prodotto ammessi nella nazione.
        /// Valori posssibili APT000903, APT000904, APT000962 e APT000971.
        /// </summary>

        [JsonPropertyName("products")]
        [JsonConverter(typeof(Json.Converter.AnnotatedEnumIListConverter<AptusCode>))]
        public IList<AptusCode>? Products { get; set; } = null;
    }
}