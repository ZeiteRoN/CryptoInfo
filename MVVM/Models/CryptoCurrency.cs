namespace CryptoInfo.Models
{
    public class CryptoCurrency
    {
        public string id { get; set; }
        
        public string rank { get; set; }
        
        public string symbol { get; set; }
        
        public string name { get; set; }
        
        public decimal supply { get; set; }
        
        public decimal maxSupply { get; set; }
        
        public decimal marketCapUsd { get; set; }
        
        public decimal volumeUsd24Hr { get; set; }
        
        public decimal priceUsd { get; set; }
        
        public decimal changePercent24Hr { get; set; }
        
        public decimal vwap24Hr { get; set; }
        
        public List<Market> markets {get;set;}
    }
}
