using System.Configuration;
using System.Data;
using System.Windows;

namespace CryptoInfo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var lang = CryptoInfo.Properties.Settings.Default.languageCode;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            base.OnStartup(e);
        }
    }

}
