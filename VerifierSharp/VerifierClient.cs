using System.Text.Json;
using VerifierSharp.Models;

namespace VerifierSharp
{
    public class VerifierClient
    {
        private readonly string _url = "https://verifier.meetchopra.com/verify/";
        private string _apiKey = string.Empty;

        public VerifierClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<VerifierResponse> VerifyEmailAddressAsync(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress) || string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new HttpRequestException("An email address and API key are required to use this method call");
            }

            return await MakeAPICall<VerifierResponse>($"{_url}/{emailAddress}?token={_apiKey}");
        }

        private async Task<T> MakeAPICall<T>(string url)
        {
            HttpResponseMessage message = await CreateAPICall(url);
            string response = await message.Content.ReadAsStringAsync();
            return DeserializeObject<T>(response);
        }

        private async Task<HttpResponseMessage> CreateAPICall(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "VerifierSharp/1.0");
            return await client.GetAsync(url);
        }

        private T DeserializeObject<T>(string contents)
        {
            return JsonSerializer.Deserialize<T>(contents);
        }
    }
}