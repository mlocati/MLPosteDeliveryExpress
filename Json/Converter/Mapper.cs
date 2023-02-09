using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class Mapper<TEnum> where TEnum : Enum
    {
        public readonly Dictionary<TEnum, string> EnumToString;
        public readonly Dictionary<string, TEnum> StringToEnum;

        public Mapper()
        {
            var type = typeof(TEnum);
            var enumMemberAttributeType = typeof(EnumMemberAttribute);
            Dictionary<TEnum, string> enumToString = new();
            Dictionary<string, TEnum> stringToEnum = new();
            foreach (var rawValue in Enum.GetValues(type))
            {
                TEnum value = (TEnum)rawValue;
                var enumMember = type.GetMember(value.ToString())[0];
                if (enumMember.GetCustomAttributes(enumMemberAttributeType, false).First() is not EnumMemberAttribute attr || attr.Value == null)
                {
                    throw new Exception($"Missing [EnumMember] for {value}");
                }
                enumToString.Add(value, attr.Value);
                if (!stringToEnum.ContainsKey(attr.Value))
                {
                    stringToEnum.Add(attr.Value, value);
                }
            }
            this.EnumToString = enumToString;
            this.StringToEnum = stringToEnum;
        }
    }
}