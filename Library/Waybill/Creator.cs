using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Waybill
{
    public class Creator
    {
        private static readonly Lazy<JsonSerializerOptions> JsonSerializerOptionsCreator = new(() => new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IncludeFields = true,
            MaxDepth = 100,
            IgnoreReadOnlyFields = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false,
        });

        public static async Task<Response.Container> CreateAsync(IAccount account, Request.Container request)
        {
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response.Container>("postalandlogistics/parcel/waybill", request, JsonSerializerOptionsCreator.Value);
            if (response.Result.ErrorCode != 0 || response.Result.ErrorDescription != "" && response.Result.ErrorDescription != "OK")
            {
                throw new Exception($"Waybill creation failed with error code {response.Result.ErrorCode}:\n{response.Result.ErrorDescription}");
            }
            if (response.Waybills == null || response.Waybills.Count == 0)
            {
                throw new Exception("No waybills created");
            }
            foreach (var waybill in response.Waybills)
            {
                if (waybill.ErrorCode != 0 || (waybill.ErrorDescription != "" && waybill.ErrorDescription != "OK"))
                {
                    throw new Exception($"Waybill creation failed with error code {waybill.ErrorCode}:\n{waybill.ErrorDescription}");
                }
            }
            return response;
        }
    }
}