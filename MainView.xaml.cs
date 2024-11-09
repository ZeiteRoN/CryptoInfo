using System.Diagnostics;
using System.Globalization;
using System.Resources;
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
        private bool _isLightTheme = true;
        public MainView()
        {
            InitializeComponent();
            MainFrame.Content = new HomeView();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _isLightTheme = !_isLightTheme;
            string newThemePath = _isLightTheme ? "Resources/Themes/LightTheme.xaml" : "Resources/Themes/DarkTheme.xaml";
            var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri(newThemePath, UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {    string cultureCode = LanguageBox.SelectedIndex == 0 ? "en-US" : "uk-UA";
            Properties.Settings.Default.languageCode = cultureCode;
            ComboBoxItem.Content = cultureCode.Remove(0,3);
            Properties.Settings.Default.Save();
            
            string applicationPath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(applicationPath);
            Application.Current.Shutdown();
        }
    }
}