﻿namespace TEST_TASK.View_Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public class MainViewModel : INotifyPropertyChanged
    {
        private API api;
        private ObservableCollection<Cryptocurrency> cryptocurrencies;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return cryptocurrencies; }
            set
            {
                cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        public MainViewModel()
        {
            api = new API();
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>();
        }

        public async Task LoadTopCurrencies(int count)
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
