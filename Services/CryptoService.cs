using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using CryptoInfo.Models;
using Newtonsoft.Json.Linq;

namespace CryptoInfo.Services
{
    public class CryptoService
    {
        private HttpClient _httpClient;
        private const string _apiKey = "d695ac5f-327c-4691-8811-2345c4178c51";

        public CryptoService()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri("https://api.coincap.io/v2/")}; 
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrenciesAsync()
        {
            var currencies = new List<CryptoCurrency>();
            var response = await _httpClient.GetAsync("assets?limit=10");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            foreach (var item in json["data"])
            {
                currencies.Add(new CryptoCurrency
                {
                    id = item["id"]?.ToString(),
                    rank = item["rank"]?.ToString(),
                    symbol = item["symbol"]?.ToString(),
                    name = item["name"]?.ToString(),
                    supply = (decimal?)item["supply"] ?? 0,
                    maxSupply = (decimal?)item["maxSupply"] ?? 0,
                    marketCapUsd = (decimal?)item["marketCapUsd"] ?? 0,
                    volumeUsd24Hr = (decimal?)item["volumeUsd24Hr"] ?? 0,
                    priceUsd = (decimal?)item["priceUsd"] ?? 0,
                    changePercent24Hr = (decimal?)item["changePercent24Hr"] ?? 0,
                    vwap24Hr = (decimal?)item["vwap24Hr"] ?? 0,
                });
            }
            return currencies;
        }

        public async Task<CryptoCurrency> GetCryptoCurrencyAsync(string id)
        {
            var response = await _httpClient.GetAsync($"assets/{id}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            var data = json["data"] as JObject;

            var currency = new CryptoCurrency
            {
                id = data["id"]?.ToString(),
                rank = data["rank"]?.ToString(),
                symbol = data["symbol"]?.ToString(),
                name = data["name"]?.ToString(),
                supply = (decimal?)data["supply"] ?? 0,
                maxSupply = (decimal?)data["maxSupply"] ?? 0,
                marketCapUsd = (decimal?)data["marketCapUsd"] ?? 0,
                volumeUsd24Hr = (decimal?)data["volumeUsd24Hr"] ?? 0,
                priceUsd = (decimal?)data["priceUsd"] ?? 0,
                changePercent24Hr = (decimal?)data["changePercent24Hr"] ?? 0,
                vwap24Hr = (decimal?)data["vwap24Hr"] ?? 0
            };
            Console.WriteLine(currency.id);
            return currency;
        }
        
        public async Task<List<Market>> GetMarketsForCurrency(string cryptoId)
        {
            var currencyMarkets = new List<Market>();
            var response = await _httpClient.GetAsync($"assets/{cryptoId}/markets");
            response.EnsureSuccessStatusCode();
            
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            foreach (var item in json["data"])
            {
                currencyMarkets.Add(new Market
                {
                    exchangeId = item["exchangeId"].ToString(),
                    baseId = item["baseId"].ToString(),
                    baseSymbol = item["baseSymbol"].ToString(),
                    volumeUsd24Hr = item["volumeUsd24Hr"].ToString(),
                    priceUsd = item["priceUsd"].ToString(),
                    volumePercent = item["volumePercent"].ToString(),
                });
            }
            return currencyMarkets;
        }
    }
}
