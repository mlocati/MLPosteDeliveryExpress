using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Deposit
{
    public class Finder
    {
        public static async Task<List<Response.Deposit>> FindAsync(IAccount account, Request.Filter filter, bool ignoreNoDataExtracted = true)
        {
            var response = await Finder.SubmitAsync(account, filter, ignoreNoDataExtracted);
            return response.DepositItem.Deposits;
        }

        internal static async Task<Response.FilterContainer> SubmitAsync(IAccount account, Request.Filter filter, bool ignoreNoDataExtracted = true)
        {
            var client = Service.JsonHttpClient.GetInstance(account);
            var response = await client.PostJsonAsync<Response.FilterContainer>("postalandlogistics/parcel/depositsList", filter) ?? throw new Exception("Unable to parse the server response");
            if (response.Result == false)
            {
                if (!ignoreNoDataExtracted || response.ErrorCode != DepositException.ERRORCODE_NO_DATA_EXTRACTED)
                {
                    throw new DepositException(response.ErrorCode, $"Error {response.ErrorCode} looking for deposits: {response.ErrorDescription}");
                }
            }
            return response;
        }
    }
}