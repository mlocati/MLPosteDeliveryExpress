using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class ReturnToSender : ServiceWithStringParameters<ReturnToSender>, IService
    {
        public enum Reasons
        {
            /// <summary>
            /// abbandono
            /// </summary>
            Abandoned,

            /// <summary>
            /// restituire
            /// </summary>
            SendBack,
        }

        public string Code => "APT000930";

        public string Name => "Ritorno al mittente/abbandono";

        public ServiceFlags Flags => ServiceFlags.NotInWaybill;

        public readonly Reasons Reason;

        internal ReturnToSender() : this(Reasons.Abandoned)
        { }

        public ReturnToSender(Reasons reason)
        {
            this.Reason = reason;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("return", EncodeReason(this.Reason))
            );
        }

        public static ReturnToSender Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var step = DecodeReason(dictionary.Pop("return"));
            dictionary.CheckEmpty();
            return new(step);
        }

        public bool Equals(IService? other)
        {
            if (other is not ReturnToSender sameClassOther)
            {
                return false;
            }
            return sameClassOther.Reason == this.Reason;
        }

        private static string EncodeReason(Reasons step)
        {
            return step switch
            {
                Reasons.Abandoned => "A",
                Reasons.SendBack => "R",
                _ => throw new ArgumentOutOfRangeException(nameof(step)),
            };
        }

        private static Reasons DecodeReason(string str)
        {
            return str switch
            {
                "A" => Reasons.Abandoned,
                "R" => Reasons.SendBack,
                _ => throw new InvalidDataException(),
            };
        }
    }
}