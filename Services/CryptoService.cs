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

        public CryptoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrencies()
        {
            var currencies = new List<CryptoCurrency>();
            var response = await _httpClient.GetAsync($"assets?limit=10");
            response.EnsureSuccessStatusCode();
            
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            foreach (var item in json["data"])
            {
                currencies.Add(new CryptoCurrency
                {
                    id = item["id"].ToString(),
                    rank = (int)item["rank"],
                    symbol = item["symbol"].ToString(),
                    name = item["name"].ToString(),
                    supply = (decimal)item["supply"],
                    maxSupply = (decimal)item["changePrice"],
                    priceUsd = (decimal)item["priceUsd"],
                    changePercent24Hr = (decimal)item["changePercent24Hr"],
                });
            }
            return currencies;
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
