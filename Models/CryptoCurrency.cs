namespace CryptoInfo.Models
{
    public class CryptoCurrency
    {
        public string id {get;set;}
        
        public string name {get;set;}
        
        public string symbol {get;set;}
        
        public decimal currentPrice {get;set;}
        
        public string changePrice {get;set;}
        
        public string marketPrice {get;set;}
        
        public List<Market> markets {get;set;}
    }
}
