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

        private API api;

        private ObservableCollection<Cryptocurrency> cryptocurrencies;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return cryptocurrencies; }
            set
            {
                cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        public CurrenciesPageModel()
        {
            api = new API();
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            LoadTopCurrencies(10);
        }

        public async void LoadTopCurrencies(int count)
        {
            var currencies = await api.GetTopCurrencies(count);
            if (currencies != null)
            {
                Cryptocurrencies.Clear();
                foreach (var currency in currencies)
                {
                    Cryptocurrencies.Add(currency);
                }
            }
        }
    }
}
