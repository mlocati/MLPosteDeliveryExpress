using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class DeliveryDateTimeInterval<T> : ServiceWithStringParameters<T> where T : class, IService
    {
        protected class UnserializedValue
        {
            public readonly TimeOnly RangeFrom;

            public readonly TimeOnly RangeTo;

            public readonly DateOnly Date;

            public UnserializedValue(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
            {
                RangeFrom = rangeFrom;
                RangeTo = rangeTo;
                Date = date;
            }
        }

        private const string TIME_FORMAT = @"HH\:mm";
        private const string DATE_FORMAT = "yyyy-MM-dd";
        public readonly TimeOnly RangeFrom;

        public readonly TimeOnly RangeTo;

        public readonly DateOnly Date;

        protected DeliveryDateTimeInterval(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
        {
            if (rangeTo < rangeFrom)
            {
                throw new ArgumentOutOfRangeException(nameof(rangeTo));
            }
            this.RangeFrom = rangeFrom;
            this.RangeTo = rangeTo;
            this.Date = date;
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("deliveryRangeFrom", this.RangeFrom.ToString(TIME_FORMAT, CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("deliveryRangeTo", this.RangeTo.ToString(TIME_FORMAT, CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("deliveryDate", this.Date.ToString(DATE_FORMAT, CultureInfo.InvariantCulture))
            );
        }

        protected static UnserializedValue UnserializeValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            string s;
            s = dictionary.Pop("deliveryRangeFrom");
            if (!TimeOnly.TryParseExact(s, TIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly rangeFrom))
            {
                throw new InvalidDataException();
            }
            s = dictionary.Pop("deliveryRangeTo");
            if (!TimeOnly.TryParseExact(s, TIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly rangeTo))
            {
                throw new InvalidDataException();
            }
            s = dictionary.Pop("deliveryDate");
            if (!DateOnly.TryParseExact(s, DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
            {
                throw new InvalidDataException();
            }

            return new UnserializedValue(rangeFrom, rangeTo, date);
        }

        public abstract bool Equals(T other);

        public bool Equals(IService? other)
        {
            if (other is not T sameClassOther)
            {
                return false;
            }
            return this.Equals(sameClassOther);
        }
    }
}