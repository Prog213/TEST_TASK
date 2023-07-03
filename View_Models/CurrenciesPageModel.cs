using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TEST_TASK.Commands;
using TEST_TASK.Views;

namespace TEST_TASK.View_Models
{
    public class CurrenciesPageModel : ViewModelBase
    {
        public ICommand DetailPageCommand { get; }

        private CurrencyStore _currencyStore;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies => _currencyStore.Cryptocurrencies;

        public CurrenciesPageModel(CurrencyStore currencyStore)
        {
            _currencyStore= currencyStore;
        }
    }
}
