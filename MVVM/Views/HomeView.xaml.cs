using System.Windows;
using System.Windows.Controls;
using CryptoInfo.MVVM.Views;
using CryptoInfo.ViewModels;

namespace CryptoInfo;

public partial class HomeView : Page
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
    
    private void NavigateToSearchPage_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new SearchPage());
    }
}