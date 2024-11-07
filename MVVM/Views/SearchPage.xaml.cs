using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CryptoInfo.MVVM.ViewModels;

namespace CryptoInfo.MVVM.Views;

public partial class SearchPage : Page
{
    private SearchViewModel _viewModel;

    public SearchPage()
    {
        InitializeComponent();
        _viewModel = new SearchViewModel();
        DataContext = _viewModel;
    }

    private void NavigateToMainPage_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new HomeView());
    }
}