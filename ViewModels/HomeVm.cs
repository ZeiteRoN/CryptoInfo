using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptoInfo.Models;
using CryptoInfo.Services;

namespace CryptoInfo.ViewModels
{
    public class HomeVm: INotifyPropertyChanged
    {
        private readonly CryptoService _service;
        public ObservableCollection<CryptoCurrency> currencies;

        public HomeVm()
        {
            _service = new CryptoService();
            currencies = new ObservableCollection<CryptoCurrency>();
            LoadTopCryptos();
        }

        public async void LoadTopCryptos()
        {
            var cryptos = await _service.GetCryptoCurrencies();
            currencies.Clear();
            foreach (var crypto in cryptos)
            {
                currencies.Add(crypto);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
