using System;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Deposit
{
    public class Decisor
    {
        /// <exception cref="ActionException"></exception>
        public static async Task<string> TakeActionAsync(IAccount account, string shipmentID, Action action, Request.Address? address = null)
        {
            Request.ActionContainer request = new()
            {
                ReleaseAct = new()
                {
                    ShipmentID = shipmentID,
                    Action = action,
                },
            };
            request.ShipmentID.Items.Add(new()
            {
                BarCode = shipmentID,
            });
            if (address != null)
            {
                request.Address.Items.Add(address);
            }
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response.ActionContainer>("postalandlogistics/parcel/depositsRelease", request) ?? throw new Exception("Unable to parse the server response");
            switch (response.Result.Items.Count)
            {
                case 0:
                    throw new Exception("Unexpected server response (no result provided)");

                case 1:
                    break;

                default:
                    throw new Exception($"Too many response received ({response.Result.Items.Count} instead of 1).");
            }
            var result = response.Result.Items[0];
            if (result.Result != true || result.ErrorCode != "" || result.ErrorDescription != "")
            {
                throw new ActionException(result.ErrorCode, result.ErrorDescription);
            }
            return response.Description;
        }
    }
}