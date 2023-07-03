using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TEST_TASK.View_Models
{
    public class DetailPageModel : ViewModelBase
    {
        private CurrencyStore _currencyStore;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;

        public Cryptocurrency SelectedCryptocurrency
        {
            get => _currencyStore.SelectedCryptocurrency;
            set
            {
                _currencyStore.SelectedCryptocurrency = value;
                OnPropertyChanged(nameof(SelectedCryptocurrency));
            }
        }

        public DetailPageModel(CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
        }
    }
}
