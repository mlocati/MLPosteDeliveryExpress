using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Service
{
    internal class JsonHttpClient
    {
        private const string CLIENTID_SANDBOX = "c7cd7028-0f4c-4623-99b2-a0c088947be5";

        private const string SECRETID_SANDBOX = "7yh_PwK3Q9X.d_T4-U.YG_S04gyEBcY.36";

        private const string BASEADDRESS_SANDBOX = "https://apid.gp.posteitaliane.it/dev/kindergarden/";

        private const string BASEADDRESS_PRODUCTION = "https://apiw.gp.posteitaliane.it/gp/internet/";

        private const string ACCESSTOKEN_GENERATIONSCOPE_SANDBOX = "api://8f0f2c58-19a8-45ef-9f9e-8bcb0acc7657/.default";

        private const string ACCESSTOKEN_GENERATIONSCOPE_PRODUCTION = "https://postemarketplace.onmicrosoft.com/d6a78063-5570-4a87-bbd7-07326e6855d1/.default";

        private static readonly TimeSpan ACCESSTOKEN_EXPIRATION_THRESHOLD = new(0, 1, 0);

        private static readonly Dictionary<KeyValuePair<Account, bool>, JsonHttpClient> Instances = new();

        public static JsonHttpClient GetInstance(Account account)
        {
            return GetInstance(account, Options.Sandbox);
        }

        public static JsonHttpClient GetInstance(Account account, bool sandbox)
        {
            var instance = ActuallyGetInstance(account, sandbox);
            if (instance == null)
            {
                lock (Instances)
                {
                    instance = ActuallyGetInstance(account, sandbox);
                    if (instance == null)
                    {
                        instance = new JsonHttpClient(account, sandbox);
                        Instances.Add(new KeyValuePair<Account, bool>(account, sandbox), instance);
                    }
                }
            }
            return instance;
        }

        private static JsonHttpClient? ActuallyGetInstance(Account account, bool sandbox)
        {
            foreach (var key in Instances.Keys)
            {
                if (key.Key == account && key.Value == sandbox)
                {
                    return Instances[key];
                }
            }
            return null;
        }

        private readonly bool Sandbox;

        private readonly Account Account;

        private GeneratedToken? CurrentToken = null;

        private JsonHttpClient(Account account, bool sandbox)
        {
            this.Sandbox = sandbox;
            this.Account = account;
        }

        public Task<T> PostJsonAsync<T>(string relativePath)
        {
            return this.DoPostJsonAsync<T>(relativePath, "", true, null);
        }

        public Task<T> PostJsonAsync<T>(string relativePath, object postBody)
        {
            return this.DoPostJsonAsync<T>(relativePath, postBody, true, null);
        }

        public Task<T> PostJsonAsync<T>(string relativePath, object postBody, JsonSerializerOptions jsonSerializerOptions)
        {
            return this.DoPostJsonAsync<T>(relativePath, postBody, true, jsonSerializerOptions);
        }

        private async Task<T> DoPostJsonAsync<T>(string relativePath, object postBody, bool addAuthorizationToken, JsonSerializerOptions? jsonSerializerOptions)
        {
            using var client = this.CreateClient();
            if (addAuthorizationToken)
            {
                var accessToken = await this.GetAccessTokenAsync();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken);
            }
            Options.OnVerboseOutput(this, new Lazy<string>(() =>
            {
                JsonSerializerOptions logOptions;
                if (jsonSerializerOptions == null)
                {
                    logOptions = new JsonSerializerOptions();
                }
                else
                {
                    logOptions = new JsonSerializerOptions(jsonSerializerOptions);
                }
                logOptions.WriteIndented = true;
                return $"Sending JSON to {relativePath}:\n{JsonSerializer.Serialize(postBody, logOptions)}";
            }));
            using var response = await client.PostAsJsonAsync(relativePath, postBody, jsonSerializerOptions);
            using var responseStream = response.Content.ReadAsStream();
            using var reader = new StreamReader(responseStream);
            var responseText = reader.ReadToEnd();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Invalid response code when invoking {relativePath}.\n.Response code: ({response.StatusCode})\n{responseText}");
            }
            Options.OnVerboseOutput(this, responseText);
            return JsonSerializer.Deserialize<T>(responseText) ?? throw new HttpRequestException($"Invalid response when invoking {relativePath}");
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(this.Sandbox ? BASEADDRESS_SANDBOX : BASEADDRESS_PRODUCTION),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("POSTE_ClientID", this.Sandbox ? CLIENTID_SANDBOX : this.Account.ClientID);
            return client;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (this.CurrentToken != null)
            {
                var timeRemaining = this.CurrentToken.Expiration - DateTime.UtcNow;
                if (timeRemaining >= ACCESSTOKEN_EXPIRATION_THRESHOLD)
                {
                    return CurrentToken.Token;
                }
            }
            CurrentToken = await GenerateTokenAsync();
            return CurrentToken.Token;
        }

        private async Task<GeneratedToken> GenerateTokenAsync()
        {
            var payload = new
            {
                clientId = this.Sandbox ? CLIENTID_SANDBOX : Account.ClientID,
                secretId = this.Sandbox ? SECRETID_SANDBOX : Account.ClientSecret,
                scope = this.Sandbox ? ACCESSTOKEN_GENERATIONSCOPE_SANDBOX : ACCESSTOKEN_GENERATIONSCOPE_PRODUCTION,
                grantType = "client_credentials",
            };
            var response = await this.DoPostJsonAsync<TokenGenerationResponse>("user/sessions", payload, false, null);
            if (response.TokenType != "Bearer")
            {
                throw new ArgumentOutOfRangeException("token_type");
            }
            if (response.ExtExpiresIn != response.ExpiresIn)
            {
                throw new ArgumentOutOfRangeException("ext_expires_in");
            }
            return new GeneratedToken(response.AccessToken, DateTime.UtcNow.Add(new TimeSpan(0, 0, response.ExpiresIn)));
        }

        private class TokenGenerationResponse
        {
            [JsonPropertyName("token_type")]
            public string TokenType { get; set; } = "";

            [JsonPropertyName("expires_in")]
            public int ExpiresIn { get; set; } = 0;

            [JsonPropertyName("ext_expires_in")]
            public int ExtExpiresIn { get; set; } = 0;

            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; } = "";
        }

        private class GeneratedToken
        {
            public readonly string Token;
            public readonly DateTime Expiration;

            public GeneratedToken(string token, DateTime expiration)
            {
                Token = token;
                Expiration = expiration;
            }
        }
    }
}