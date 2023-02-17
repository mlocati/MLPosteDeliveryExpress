using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class FixedDayDelivery : ServiceWithStringParameters<FixedDayDelivery>, IService
    {
        public enum TimeSlot
        {
            Morning,
            Afternoon,
        };

        public bool? DataInWaybill => true;
        public string Code => "APT000912";
        public string Name => "Consegna a giorno - Orario definito (aka Consegna a giorno Stabilito)";

        public readonly int Day;
        public readonly int Month;
        public readonly TimeSlot Time;

        internal FixedDayDelivery()
            : this(1, 1, TimeSlot.Morning)
        {
        }

        public FixedDayDelivery(int day, int month, TimeSlot time)
        {
            if (day < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(day));
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month));
            }
            switch (month)
            {
                case 2:
                    if (day > 29)
                    {
                        throw new ArgumentOutOfRangeException(nameof(day));
                    }
                    break;

                default:
                    if (day > DateTime.DaysInMonth(DateTime.Today.Year, month))
                    {
                        throw new ArgumentOutOfRangeException(nameof(day));
                    }
                    break;
            }
            this.Day = day;
            this.Month = month;
            this.Time = time;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            var days = "G"
                + this.Day.ToString("00", CultureInfo.InvariantCulture)
                + this.Month.ToString("00", CultureInfo.InvariantCulture)
                + EncodeTimeSlot(this.Time)
            ;
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("days", days)
            );
        }

        public static FixedDayDelivery Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var days = dictionary.Pop("days");
            var match = Regex.Match(days, "^G(?<day>[0-3][0-9])(?<month>[01][0-9])(?<time>.)$", RegexOptions.ExplicitCapture);
            if (!match.Success)
            {
                throw new InvalidDataException();
            }
            var day = int.Parse(match.Groups["day"].Value);
            var month = int.Parse(match.Groups["month"].Value);
            var time = DecodeTimeSlot(match.Groups["time"].Value[0]);
            dictionary.CheckEmpty();
            return new(day, month, time);
        }

        /// <exception cref="InvalidDataException" />
        private static TimeSlot DecodeTimeSlot(char chr)
        {
            return chr switch
            {
                'M' => TimeSlot.Morning,
                'P' => TimeSlot.Afternoon,
                _ => throw new InvalidDataException(),
            };
        }

        private static char EncodeTimeSlot(TimeSlot timeSlot)
        {
            return timeSlot switch
            {
                TimeSlot.Morning => 'M',
                TimeSlot.Afternoon => 'P',
                _ => throw new ArgumentOutOfRangeException(nameof(timeSlot)),
            };
        }
    }
}