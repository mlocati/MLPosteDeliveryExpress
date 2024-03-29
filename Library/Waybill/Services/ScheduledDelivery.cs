﻿using System;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class ScheduledDelivery : ServiceWithStringParameters<ScheduledDelivery>, IService
    {
        public enum Hour : byte
        {
            No = 0,
            Morning = 1,
            Afternoon = 2,
        };

        public class Day : IEquatable<Day>
        {
            public readonly Hour Monday;
            public readonly Hour Tuesday;
            public readonly Hour Wednesday;
            public readonly Hour Thursday;
            public readonly Hour Friday;

            public Day(Hour monday = Hour.No, Hour tuesday = Hour.No, Hour wednesday = Hour.No, Hour thursday = Hour.No, Hour friday = Hour.No)
            {
                this.Monday = monday;
                this.Tuesday = tuesday;
                this.Wednesday = wednesday;
                this.Thursday = thursday;
                this.Friday = friday;
            }

            public bool Equals(Day? other)
            {
                if (other == null)
                {
                    return false;
                }
                return other.Monday == this.Monday
                    && other.Tuesday == this.Tuesday
                    && other.Wednesday == this.Wednesday
                    && other.Thursday == this.Thursday
                    && other.Friday == this.Friday
                ;
            }

            public override bool Equals(object? obj)
            {
                return this.Equals(obj as Day);
            }

            public override int GetHashCode()
            {
                return 0
                    + (((int)this.Monday) << 0)
                    + (((int)this.Tuesday) << 2)
                    + (((int)this.Wednesday << 4))
                    + (((int)this.Thursday << 8))
                    + (((int)this.Friday << 16))
                ;
            }
        }

        public string Code => "APT000909";
        public string Name => "Consegna programmata";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public readonly Day Days;

        public readonly string TimeSlotsDescription;

        internal ScheduledDelivery()
            : this(new Day(), "")
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="days"></param>
        /// <param name="timeSlotsDescription">Prima l'eventuale fascia mattutina poi l'eventuale fascia pomeridiana</param>
        public ScheduledDelivery(Day days, string timeSlotsDescription)
        {
            this.Days = days;
            this.TimeSlotsDescription = timeSlotsDescription;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            var days = "G"
                + EncodeHour(this.Days.Monday)
                + EncodeHour(this.Days.Tuesday)
                + EncodeHour(this.Days.Wednesday)
                + EncodeHour(this.Days.Thursday)
                + EncodeHour(this.Days.Friday)
            ;
            this.WriteDictionary(
                writer,
                new("days", days),
                new("note", this.TimeSlotsDescription)
            );
        }

        public static ScheduledDelivery Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var match = Regex.Match(dictionary.Pop("days"), "^G(?<days>[012]{5})$", RegexOptions.ExplicitCapture);
            if (!match.Success)
            {
                throw new InvalidDataException();
            }
            string chunk = match.Groups["days"].Value;
            var day = new Day(
                DecodeHour(chunk[0]),
                DecodeHour(chunk[1]),
                DecodeHour(chunk[2]),
                DecodeHour(chunk[3]),
                DecodeHour(chunk[4])
            );
            var timeSlotsDescription = dictionary.Pop("note");
            dictionary.CheckEmpty();
            return new(day, timeSlotsDescription);
        }

        /// <exception cref="InvalidDataException" />
        private static Hour DecodeHour(char chr)
        {
            return chr switch
            {
                '0' => Hour.No,
                '1' => Hour.Morning,
                '2' => Hour.Afternoon,
                _ => throw new InvalidDataException(),
            };
        }

        private static char EncodeHour(Hour hour)
        {
            return hour switch
            {
                Hour.No => '0',
                Hour.Morning => '1',
                Hour.Afternoon => '2',
                _ => throw new ArgumentOutOfRangeException(nameof(hour)),
            };
        }

        public bool Equals(IService? other)
        {
            if (other is not ScheduledDelivery sameClassOther)
            {
                return false;
            }
            return sameClassOther.Days.Equals(this.Days)
                && sameClassOther.TimeSlotsDescription == this.TimeSlotsDescription
            ;
        }
    }
}