using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoInfo.MVVM.ViewModels;
using CryptoInfo.MVVM.Views;
using CryptoInfo.Services;
using CryptoInfo.ViewModels;

namespace CryptoInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }

        private void OpenSearchWindow_Click(object sender, RoutedEventArgs e)
        {
            // Приховуємо MainWindow
            this.Hide();

            // Створюємо і відкриваємо SearchWindow
            var searchWindow = new SearchWindow();
            
            searchWindow.Closed += (s, args) => this.Show();
            
            searchWindow.Show();
        }
    }
}