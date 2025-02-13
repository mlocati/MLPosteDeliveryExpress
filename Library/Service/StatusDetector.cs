using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace MLPosteDeliveryExpress.Service
{
    public class StatusDetector
    {
        private class FakeSandboxAccount : ISandboxAccount
        {
            public string ClientID { get => "wrongClientID"; }

            public string ClientSecret { get => "wrongClientSecret"; }

            public string CostCenterCode { get => "CDC-12345678"; }
        }

        public static async Task<bool> IsWebServiceAvailableAsync(bool sandbox = false)
        {
            IAccount wrongAccount;
            if (sandbox)
            {
                wrongAccount = new FakeSandboxAccount();
            }
            else
            {
                wrongAccount = new Account("wrongClientID", "wrongClientSecret", "wrongCostCenterCode");
            }
            var client = Service.JsonHttpClient.GetInstance(wrongAccount);
            try
            {
                await client.GetJsonAsync<object>("servive/get_status");
            }
            catch (InvalidAuthorizationException)
            {
                return true;
            }
            catch (HttpRequestException x)
            {
                if (x.StatusCode == null)
                {
                    return false;
                }
                throw;
            }
            throw new Exception("Expected failure");
        }
    }
}