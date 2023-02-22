using System;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Taric
{
    public class Fetcher
    {
        public static Response Fetch(IAccount account)
        {
            using var fetcher = FetchAsync(account);
            fetcher.Wait();
            return fetcher.Result;
        }

        public static async Task<Response> FetchAsync(IAccount account)
        {
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response>("postalandlogistics/parcel/international/taric");
            if (response.Result.ErrorCode != 0 || response.Result.ErrorDescription != "" && response.Result.ErrorDescription != "OK")
            {
                throw new Exception($"Country info fetch failed with error code {response.Result.ErrorCode}:\n{response.Result.ErrorDescription}");
            }
            return response;
        }
    }
}