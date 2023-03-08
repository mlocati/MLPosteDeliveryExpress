using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public class Finder
    {
        /// <summary>
        /// Finds the pickup bookinds.
        /// </summary>
        /// <exception cref="BookingException">When the communication suceeded, but the server returned an error.</exception>
        /// <exception cref="Exception">If commincation fails.</exception>
        public static async Task<List<Response.FoundPickup>> SubmitAsync(IAccount account, Request.Filter filter)
        {
            Request.FilterContainer request = new()
            {
                Filter = filter,
            };
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response.FoundContainer>("postalandlogistics/parcel/pickupReport", request) ?? throw new Exception("Unable to parse the server response");
            if (response.Success == false)
            {
                if (response.ErrorCode == "E0003" && (response?.FoundPickupContainer?.Items ?? new()).Count == 0)
                {
                    return new();
                }
#pragma warning disable CS8602
                throw new BookingException(response.ErrorCode, $"Error {response.ErrorCode} booking a pickup: {response.ErrorDescription}");
#pragma warning restore CS8602
            }
            return response?.FoundPickupContainer?.Items ?? new();
        }
    }
}