using StocksApp.ServiceContracts;
using System.Text.Json; // This is necessary to convert what we get ion the API response

namespace StocksApp.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FinnhubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol) // This is the task that makes the request
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=ch73ed9r01qhmmuo0bi0ch73ed9r01qhmmuo0big"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage); //This ios to receive the message

                Stream stream = httpResponseMessage.Content.ReadAsStream(); // This is to create the stream to read it

                StreamReader streamReader = new StreamReader(stream); //This is to actual read the message from response body

                string response = streamReader.ReadToEnd();
                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response); // We are converting what we get in response into a dictionary 
                if (responseDictionary == null) // In case it fails
                    throw new InvalidOperationException("No response from finnhub server");

                if (responseDictionary.ContainsKey("error")) // in case there is an error
                    throw new InvalidOperationException(Convert.ToString(responseDictionary ["error"]));
                return responseDictionary;

            }
        }
    }
}
