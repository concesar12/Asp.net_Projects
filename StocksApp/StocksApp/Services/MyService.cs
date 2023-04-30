namespace StocksApp.Services
{
    public class MyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task method()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=ch73ed9r01qhmmuo0bi0ch73ed9r01qhmmuo0big"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage); //This ios to receive the message

                Stream stream = httpRequestMessage.Content.ReadAsStream(); // This is to create the stream to read it

                StreamReader streamReader = new StreamReader(stream); //This is to actual read the message from response body

                string response = streamReader.ReadToEnd();

            }
        }
    }
}
