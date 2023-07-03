using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TEST_TASK.View_Models
{
    public class CurrencyStore
    {
        public ObservableCollection<Cryptocurrency> Cryptocurrencies { get; }
        public Cryptocurrency SelectedCryptocurrency { get; set; }

        public CurrencyStore() {
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            LoadTopCurrencies(10);
        }

        public async void LoadTopCurrencies(int count)
        {
            API api = new API();
            var currencies = await api.GetTopCurrencies(count);
            if (currencies != null)
            {
                Cryptocurrencies.Clear();
                foreach (var currency in currencies)
                {
                    Cryptocurrencies.Add(currency);
                }
            }
            SelectedCryptocurrency = Cryptocurrencies.Count > 0 ? Cryptocurrencies[0] : null;
        }
    }
}
