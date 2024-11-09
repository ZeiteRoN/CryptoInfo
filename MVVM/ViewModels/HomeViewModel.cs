using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CryptoInfo.Models;
using CryptoInfo.MVVM.Commands;
using CryptoInfo.Services;
using CryptoInfo.Resources.LanguagePacks;

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
            if (_baseCurrency != value)
            {
                _baseCurrency = value;
                OnPropertyChanged();
            }
        }
    }

    private string _targetCurrency;
    public string TargetCurrency
    {
        get => _targetCurrency;
        set
        {
            if (_targetCurrency != value)
            {
                _targetCurrency = value;
                OnPropertyChanged();
            }
        }
    }
    
    private CryptoCurrency _selectedBaseCurrency;
    public CryptoCurrency SelectedBaseCurrency
    {
        get => _selectedBaseCurrency;
        set
        {
            _selectedBaseCurrency = value;
            BaseCurrency = value?.symbol;
            OnPropertyChanged();
        }
    }

    private CryptoCurrency _selectedTargetCurrency;
    public CryptoCurrency SelectedTargetCurrency
    {
        get => _selectedTargetCurrency;
        set
        {
            _selectedTargetCurrency = value;
            TargetCurrency = value?.symbol;
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
        Cryptos.Clear();
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

        if (BaseCurrency == TargetCurrency)
        {
            MessageBox.Show("Base and target currencies cannot be the same. Please choose different currencies.", 
                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        
        var baseCurrency = Cryptos.FirstOrDefault(c => c.symbol.Equals(BaseCurrency, StringComparison.OrdinalIgnoreCase));
        var targetCurrency = Cryptos.FirstOrDefault(c => c.symbol.Equals(TargetCurrency, StringComparison.OrdinalIgnoreCase));
        
        if (baseCurrency == null || targetCurrency == null)
        {
            MessageBox.Show("Selected currency not found in the top 10 list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        if (baseCurrency.priceUsd <= 0 || targetCurrency.priceUsd <= 0)
        {
            MessageBox.Show("Price data for the selected currencies is invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        ConversionResult = Math.Round((AmountToConvert * baseCurrency.priceUsd) / targetCurrency.priceUsd, 2);
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
