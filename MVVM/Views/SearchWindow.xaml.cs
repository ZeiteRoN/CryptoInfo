using System.Windows;
using System.Windows.Controls;
using CryptoInfo.MVVM.ViewModels;

namespace CryptoInfo.MVVM.Views;

public partial class SearchWindow : Window
{
    private SearchViewModel _viewModel;

    public SearchWindow()
    {
        InitializeComponent();
        _viewModel = new SearchViewModel();
        DataContext = _viewModel;
    }

    private void returnToMainWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}