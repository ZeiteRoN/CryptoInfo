using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptoInfo.Models;
using CryptoInfo.Services;

namespace CryptoInfo.ViewModels
{
    public class HomeViewModel: INotifyPropertyChanged
    {
        private readonly CryptoService _service;
        public ObservableCollection<CryptoCurrency> Cryptos { get; set; }

        public HomeViewModel()
        {
            _service = new CryptoService();
            Cryptos = new ObservableCollection<CryptoCurrency>();
            LoadTopCryptos();
        }

        private async void LoadTopCryptos()
        {
            var cryptos = await _service.GetCryptoCurrenciesAsync();
            foreach (var crypto in cryptos)
            {
                Cryptos.Add(crypto);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
