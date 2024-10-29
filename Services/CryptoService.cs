using System.Net.Http;

namespace CryptoInfo.Services
{
    public class CryptoService
    {
        private HttpClient _httpClient;

        public CryptoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }
    }
}
