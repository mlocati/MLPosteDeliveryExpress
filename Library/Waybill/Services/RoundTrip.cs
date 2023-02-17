using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class RoundTrip : ServiceWithStringParameters<RoundTrip>, IService
    {
        public enum Steps
        {
            /// <summary>
            /// Andata
            /// </summary>
            WayOut,

            /// <summary>
            /// Ritorno
            /// </summary>
            WayIn,
        }

        public string Code => "APT000929";

        public string Name => "Andata & Ritorno";

        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public readonly Steps Step;

        public RoundTrip() : this(Steps.WayIn)
        { }

        public RoundTrip(Steps step)
        {
            this.Step = step;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("roundtrip", EncodeStep(this.Step))
            );
        }

        public static RoundTrip Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var step = DecodeStep(dictionary.Pop("roundtrip"));
            dictionary.CheckEmpty();
            return new(step);
        }

        public bool Equals(IService? other)
        {
            if (other is not RoundTrip sameClassOther)
            {
                return false;
            }
            return sameClassOther.Step == this.Step;
        }

        private static string EncodeStep(Steps step)
        {
            return step switch
            {
                Steps.WayOut => "AND",
                Steps.WayIn => "RIT",
                _ => throw new ArgumentOutOfRangeException(nameof(step)),
            };
        }

        private static Steps DecodeStep(string str)
        {
            return str switch
            {
                "AND" => Steps.WayOut,
                "RIT" => Steps.WayIn,
                _ => throw new InvalidDataException(),
            };
        }
    }
}