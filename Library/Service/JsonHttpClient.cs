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
        private const string BASEADDRESS_SANDBOX = "https://apid.gp.posteitaliane.it/dev/kindergarden/";

        private const string BASEADDRESS_PRODUCTION = "https://apiw.gp.posteitaliane.it/gp/internet/";

        private const string ACCESSTOKEN_GENERATIONSCOPE_SANDBOX = "api://8f0f2c58-19a8-45ef-9f9e-8bcb0acc7657/.default";

        private const string ACCESSTOKEN_GENERATIONSCOPE_PRODUCTION = "https://postemarketplace.onmicrosoft.com/d6a78063-5570-4a87-bbd7-07326e6855d1/.default";

        private static readonly TimeSpan ACCESSTOKEN_EXPIRATION_THRESHOLD = new(0, 1, 0);

        private static readonly Dictionary<string, JsonHttpClient> Instances = new();

        public static JsonHttpClient GetInstance(IAccount account)
        {
            var key = $"{account.ClientID}\0{account.ClientSecret}\0{account.CostCenterCode}";
            if (JsonHttpClient.Instances.TryGetValue(key, out JsonHttpClient? instance))
            {
                return instance;
            }
            lock (JsonHttpClient.Instances)
            {
                if (JsonHttpClient.Instances.TryGetValue(key, out instance))
                {
                    return instance;
                }
                instance = new JsonHttpClient(account);
                JsonHttpClient.Instances.Add(key, instance);
                return instance;
            }
        }

        private readonly IAccount Account;

        private AccessToken? CurrentAccessToken = null;

        private JsonHttpClient(IAccount account)
        {
            this.Account = account;
        }

        public Task<T> PostJsonAsync<T>(string relativePath)
        {
            return this.DoPostJsonAsync<T>(relativePath, "", false, null);
        }

        public Task<T> PostJsonAsync<T>(string relativePath, object postBody)
        {
            return this.DoPostJsonAsync<T>(relativePath, postBody, false, null);
        }

        public Task<T> PostJsonAsync<T>(string relativePath, object postBody, JsonSerializerOptions jsonSerializerOptions)
        {
            return this.DoPostJsonAsync<T>(relativePath, postBody, false, jsonSerializerOptions);
        }

        private async Task<T> DoPostJsonAsync<T>(string relativePath, object postBody, bool isAccessTokenGeneration, JsonSerializerOptions? jsonSerializerOptions)
        {
            var accessToken = isAccessTokenGeneration ? null : await this.GetAccessTokenAsync();
            using var client = this.CreateClient();
            if (accessToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken);
            }
            Options.OnVerboseOutput(this, new Lazy<Service.Message>(() =>
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

                return new(isAccessTokenGeneration ? Message.MessageType.TokenRequestJson : Message.MessageType.RequestJson, JsonSerializer.Serialize(postBody, logOptions));
            }));
            using var response = await client.PostAsJsonAsync(relativePath, postBody, jsonSerializerOptions);
            using var responseStream = response.Content.ReadAsStream();
            using var reader = new StreamReader(responseStream);
            var responseText = reader.ReadToEnd();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Invalid response code when invoking {relativePath}.\n.Response code: ({response.StatusCode})\n{responseText}");
            }

            Options.OnVerboseOutput(this, new Service.Message(isAccessTokenGeneration ? Message.MessageType.TokenResponseJson : Message.MessageType.ResponseJson, responseText));
            return JsonSerializer.Deserialize<T>(responseText) ?? throw new HttpRequestException($"Invalid response when invoking {relativePath}");
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(this.Account is SandboxAccount ? BASEADDRESS_SANDBOX : BASEADDRESS_PRODUCTION),
                Timeout = new TimeSpan(0, 0, 30)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("POSTE_ClientID", this.Account.ClientID);
            Options.OnHttpClientInitialization(this, client);
            return client;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (this.CurrentAccessToken != null)
            {
                var timeRemaining = this.CurrentAccessToken.Expiration - DateTime.UtcNow;
                if (timeRemaining >= ACCESSTOKEN_EXPIRATION_THRESHOLD)
                {
                    return this.CurrentAccessToken.Token;
                }
            }
            this.CurrentAccessToken = await GenerateAccessTokenAsync();
            return CurrentAccessToken.Token;
        }

        private async Task<AccessToken> GenerateAccessTokenAsync()
        {
            var payload = new
            {
                clientId = this.Account.ClientID,
                secretId = this.Account.ClientSecret,
                scope = this.Account is SandboxAccount ? ACCESSTOKEN_GENERATIONSCOPE_SANDBOX : ACCESSTOKEN_GENERATIONSCOPE_PRODUCTION,
                grantType = "client_credentials",
            };
            var response = await this.DoPostJsonAsync<TokenGenerationResponse>("user/sessions", payload, true, null);
            if (response.TokenType != "Bearer")
            {
                if (response.Error.Length > 0 || response.ErrorDescription.Length > 0)
                {
                    throw new Exception($"Error generating the access token: {response.Error}{Environment.NewLine}{response.ErrorDescription}");
                }
                throw new ArgumentOutOfRangeException("token_type", $"token_type is '{response.TokenType}' instead of 'Bearer'");
            }
            if (response.ExtExpiresIn != response.ExpiresIn)
            {
                throw new ArgumentOutOfRangeException("ext_expires_in", $"ext_expires_in is {response.ExtExpiresIn} but expires_in is {response.ExpiresIn}");
            }
            return new AccessToken(response.AccessToken, DateTime.UtcNow.Add(new TimeSpan(0, 0, response.ExpiresIn)));
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

            [JsonPropertyName("error")]
            public string Error { get; set; } = "";

            [JsonPropertyName("error_description")]
            public string ErrorDescription { get; set; } = "";
        }

        private class AccessToken
        {
            public readonly string Token;
            public readonly DateTime Expiration;

            public AccessToken(string token, DateTime expiration)
            {
                Token = token;
                Expiration = expiration;
            }
        }
    }
}