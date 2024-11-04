namespace CryptoInfo.Models
{
    public class Market
    {
        public int exchangeId { get; set; }
    
        public string baseId { get; set; }
    
        public string baseSymbol { get; set; }
    
        public decimal volumeUsd24Hr { get; set; }
        
        public decimal priceUsd { get; set; }
        
        public decimal volumePercent { get; set; }
    }
}

