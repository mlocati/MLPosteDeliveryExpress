using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.DeliveryPoint
{
    public class Finder
    {
        private static readonly Lazy<Regex> ZipCodeRegex = new(() => new("^[0-9]{5}$", RegexOptions.Compiled));

        private static readonly Mapper<ServiceType> ServiceTypeMapper = new();

        public static async Task<IList<Response.DeliveryPoint>> FindAsync(IAccount account, string zipCode, ServiceType serviceType)
        {
            List<string> query = new();
            if (!ZipCodeRegex.Value.IsMatch(zipCode))
            {
                throw new Exception("The ZIP Code must me 5 digits");
            }
            query.Add("zipCode=" + Uri.EscapeDataString(zipCode));
            query.Add("serviceType=" + Uri.EscapeDataString(ServiceTypeMapper.EnumToString[serviceType]));
            var relativePath = "postalandlogistics/parcel/deliveryPoint?" + string.Join("&", query.ToArray());
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.GetJsonAsync<Response.Search>(relativePath) ?? throw new Exception("Unable to parse the server response");
            var responseReturn = response.Return;
            if (responseReturn.Code != 0 || responseReturn.Outcome == false)
            {
                throw new Response.Exception(responseReturn.Code);
            }
            return responseReturn.DeliveryPoints;
        }
    }
}