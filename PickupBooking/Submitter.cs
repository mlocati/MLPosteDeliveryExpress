using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public class Submitter
    {
        private static readonly Lazy<JsonSerializerOptions> JsonSerializerOptionsCreator = new(() => new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            IncludeFields = true,
            MaxDepth = 100,
            IgnoreReadOnlyFields = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false,
        });

        /// <summary>
        /// Returns the ID of the pickup booking, or an empty string in case of a Cancel operation.
        /// </summary>
        /// <exception cref="BookingException">When the communication suceeded, but the server returned an error.</exception>
        /// <exception cref="Exception">If commincation fails.</exception>
        public static string Submit(Account account, Request.Pickup item)
        {
            using var getter = SubmitAsync(account, item);
            getter.Wait();
            return getter.Result;
        }

        /// <summary>
        /// Returns the ID of the pickup booking, or an empty string in case of a Cancel operation.
        /// </summary>
        public static async Task<string> SubmitAsync(Account account, Request.Pickup item)
        {
            var request = new Request.Container();
            request.PickupContainer.Pickup = item;
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response.Container>("postalandlogistics/parcel/pickup", request, JsonSerializerOptionsCreator.Value);
            if (response.ResultContainer.Result.Success == false)
            {
                throw new BookingException(response.ResultContainer.Result.ErrorCode, $"Error {response.ResultContainer.Result.ErrorCode} booking a pickup: {response.ResultContainer.Result.ErrorDescription}");
            }
            if (item.Operation != Operation.Cancel && response.BookingID == "")
            {
                throw new Exception("Error booking a pickup: booking ID not received");
            }
            return response.BookingID;
        }
    }
}