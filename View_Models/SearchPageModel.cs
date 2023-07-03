using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TEST_TASK.View_Models
{
    class SearchPageModel : ViewModelBase
    {
        private CurrencyStore _currencyStore;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;

        private ObservableCollection<Cryptocurrency> searchResults;

        public ObservableCollection<Cryptocurrency> SearchResults
        {
            get { return searchResults; }
            set
            {
                searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
                SearchCryptocurrencies();
            }
        }

        public ICommand SearchCommand { get; private set; }

        public SearchPageModel(CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
            SearchResults = new ObservableCollection<Cryptocurrency>();
            SearchCommand = new RelayCommand(SearchCryptocurrencies);
        }

        private void SearchCryptocurrencies()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
            {
                SearchResults.Clear();
                return;
            }

            var results = Cryptocurrencies.Where(c => c.Name.ToLower().Contains(SearchKeyword.ToLower()));
            SearchResults.Clear();
            foreach (var result in results)
            {
                SearchResults.Add(result);
            }
        }
    }
}
