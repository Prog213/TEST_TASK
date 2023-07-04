using System.Windows;
using TEST_TASK.View_Models;

namespace TEST_TASK
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private CurrencyStore _currencyStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _currencyStore = new CurrencyStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new CurrenciesPageModel(_currencyStore, _navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore,_currencyStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
