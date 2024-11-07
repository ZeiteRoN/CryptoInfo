using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CryptoInfo.Models;
using CryptoInfo.MVVM.Commands;
using CryptoInfo.Services;

namespace CryptoInfo.ViewModels
{
public class HomeViewModel : INotifyPropertyChanged
{
    private readonly CryptoService _service;

    private string _baseCurrency;
    public string BaseCurrency
    {
        get => _baseCurrency;
        set
        {
            _baseCurrency = value;
            OnPropertyChanged();
        }
    }

    private string _targetCurrency;
    public string TargetCurrency
    {
        get => _targetCurrency;
        set
        {
            _targetCurrency = value;
            OnPropertyChanged();
        }
    }

    private decimal _amountToConvert;
    public decimal AmountToConvert
    {
        get => _amountToConvert;
        set
        {
            _amountToConvert = value;
            OnPropertyChanged();
        }
    }

    private decimal? _conversionResult;
    public decimal? ConversionResult
    {
        get => _conversionResult;
        private set
        {
            _conversionResult = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<CryptoCurrency> Cryptos { get; set; }
    public ICommand ConvertCurrencyCommand { get; }

    public HomeViewModel()
    {
        _service = new CryptoService();
        Cryptos = new ObservableCollection<CryptoCurrency>();
        LoadTopCryptos();
        ConvertCurrencyCommand = new RelayCommand(ConvertCurrencies);
    }

    private async void LoadTopCryptos()
    {
        var cryptos = await _service.GetCryptoCurrenciesAsync();
        Cryptos.Clear(); // Очистка перед додаванням нових даних
        foreach (var crypto in cryptos)
        {
            Cryptos.Add(crypto);
        }
    }

    private void ConvertCurrencies()
    {
        if (string.IsNullOrWhiteSpace(BaseCurrency) || string.IsNullOrWhiteSpace(TargetCurrency))
        {
            MessageBox.Show("Please select both currencies.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var baseCurrency = Cryptos.FirstOrDefault(c => c.symbol.Equals(BaseCurrency, StringComparison.OrdinalIgnoreCase));
        var targetCurrency = Cryptos.FirstOrDefault(c => c.symbol.Equals(TargetCurrency, StringComparison.OrdinalIgnoreCase));

        if (baseCurrency == null || targetCurrency == null)
        {
            MessageBox.Show("Selected currency not found in the top 10 list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        ConversionResult = (AmountToConvert * baseCurrency.priceUsd) / targetCurrency.priceUsd;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
