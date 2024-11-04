using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptoInfo.Models;
using CryptoInfo.Services;

namespace CryptoInfo.ViewModels;

public class DetailedCurrInfoVm
{
    private readonly CryptoService _service;

    private string id;
    public ObservableCollection<CryptoCurrency> Cryptos { get; set; }

    public DetailedCurrInfoVm(string id)
    {
        this.id = id;
        _service = new CryptoService();
        Cryptos = new ObservableCollection<CryptoCurrency>();
        LoadCryptoInfo();
    }

    private async void LoadCryptoInfo()
    {
        var crypto = await _service.GetCryptoCurrencyAsync(id);
        Cryptos.Add(crypto);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}