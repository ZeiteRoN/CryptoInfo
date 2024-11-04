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
            var currency = new CryptoCurrency();
            var response = await _httpClient.GetAsync($"assets?id={id}");
            response.EnsureSuccessStatusCode();
            
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            
            currency.id = json["id"]?.ToString();
            return currency;
        }
        
        public async Task<List<Market>> GetMarketsForCurrency(string cryptoId)
        {
            var currencyMarkets = new List<Market>();
            var response = await _httpClient.GetAsync($"assets/{cryptoId}/markets)");
            response.EnsureSuccessStatusCode();
            
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            foreach (var item in json["data"])
            {
                currencyMarkets.Add(new Market
                {
                    exchangeId = (int)item["exchangeId"],
                    baseId = item["baseId"].ToString(),
                    baseSymbol = item["baseSymbol"].ToString(),
                    volumeUsd24Hr = (decimal)item["volumeUsd24Hr"],
                    priceUsd = (decimal)item["priceUsd"],
                    volumePercent = (decimal)item["volumePercent"],
                });
            }
            return currencyMarkets;
        }
    }
}
