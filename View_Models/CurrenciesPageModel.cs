using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TEST_TASK.Commands;
using TEST_TASK.Views;

namespace TEST_TASK.View_Models
{
    public class CurrenciesPageModel : ViewModelBase
    {
        public ICommand ListBox_Changed { get; }

        private CurrencyStore _currencyStore;
        private NavigationStore _navigationStore;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;
        public Cryptocurrency SelectedCryptocurrency
        {
            get { return null; }
            set
            {
                _currencyStore.SelectedCryptocurrency = value;
                OnPropertyChanged(nameof(SelectedCryptocurrency));
            }
        }

        public CurrenciesPageModel(CurrencyStore currencyStore, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _currencyStore = currencyStore;
            ListBox_Changed = new NavigateCommand<DetailPageModel>
                (new NavigationService<DetailPageModel>(_navigationStore, () => new DetailPageModel(_currencyStore)));
        }
    }
}
