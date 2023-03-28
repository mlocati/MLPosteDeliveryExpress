using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Tracking
{
    public class Tracker
    {
        public static async Task<(Response.Shipment, List<Response.Message>)> TrackAsync(IAccount account, string waybillNumber, bool lastTracingState = false)
        {
            var client = Service.JsonHttpClient.GetInstance(account);
            var relativePath = $"postalandlogistics/parcel/tracking?statusDescription=E&customerType=DQ&&waybillNumber={Uri.EscapeDataString(waybillNumber)}&lastTracingState=" + (lastTracingState ? 'S' : 'N');
            var response = await client.GetJsonAsync<Response.Container>(relativePath);
            if (response.Return == null)
            {
                throw new Exception("Unrecognized response");
            }
            if (response.Return.Code != 0 || response.Return.Outcome != true || response.Return.Result != true)
            {
                throw new TrackingException(response.Return.Code, $"Error {response.Return.Code} while retrieving the tracking");
            }
            switch (response.Return.Shipment.Count)
            {
                case 0:
                    throw new Exception("Unrecognized response");
                case 1:
                    break;

                default:
                    throw new Exception("Unrecognized response (too many shipments)");
            };
            List<Response.Message> messages = new();
            foreach (var list1 in response.Return.Messages)
            {
                messages.AddRange(list1.Messages);
            }
            return (response.Return.Shipment[0], messages);
        }
    }
}