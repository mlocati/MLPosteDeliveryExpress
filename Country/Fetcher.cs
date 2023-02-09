﻿using System;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Country
{
    public class Fetcher
    {
        public static Response Fetch(Account account)
        {
            return Fetch(account, true);
        }

        public static Response Fetch(Account account, bool includeItaly)
        {
            using var fetcher = FetchAsync(account, includeItaly);
            fetcher.Wait();
            return fetcher.Result;
        }

        public static Task<Response> FetchAsync(Account account)
        {
            return FetchAsync(account, true);
        }

        public static async Task<Response> FetchAsync(Account account, bool includeItaly)
        {
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response>("postalandlogistics/parcel/international/nations");
            if (response.Result.ErrorCode != 0 || response.Result.ErrorDescription != "" && response.Result.ErrorDescription != "OK")
            {
                throw new Exception($"Country fetch failed with error code {response.Result.ErrorCode}:\n{response.Result.ErrorDescription}");
            }
            if (response.Countries == null || response.Countries.Count == 0)
            {
                throw new Exception("No countries fetched.");
            }
            if (includeItaly)
            {
                var found = false;
                foreach (var country in response.Countries)
                {
                    if (country.ISO2 == "IT")
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    response.Countries.Add(Country.Italy.Value);
                }
            }
            return response;
        }
    }
}