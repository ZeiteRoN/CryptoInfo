using System.Windows;
using System.Windows.Controls;
using CryptoInfo.ViewModels;

namespace CryptoInfo;

public partial class HomeView : Page
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeVm();
    }
}