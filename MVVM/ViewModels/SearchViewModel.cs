using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CryptoInfo.Models;
using CryptoInfo.MVVM.Commands;
using CryptoInfo.Services;

namespace CryptoInfo.MVVM.ViewModels;

public class SearchViewModel : INotifyPropertyChanged
{
    private readonly CryptoService _service;
    private CryptoCurrency _selectedCryptocurrency;
    private string _searchQuery;

    public SearchViewModel()
    {
        _service = new CryptoService();
        SearchCommand = new RelayCommand(async () => await LoadCryptoInfo());
    }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged();
        }
    }

    public CryptoCurrency SelectedCryptocurrency
    {
        get => _selectedCryptocurrency;
        set
        {
            _selectedCryptocurrency = value;
            OnPropertyChanged();
        }
    }

    public ICommand SearchCommand { get; }

    public async Task LoadCryptoInfo()
    {
        if (!string.IsNullOrWhiteSpace(SearchQuery))
        {
            SelectedCryptocurrency = await _service.GetCryptoCurrencyAsync(SearchQuery.ToLower());
        }
        Console.WriteLine($"Name: {SelectedCryptocurrency.name}, Price: {SelectedCryptocurrency.priceUsd}");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}