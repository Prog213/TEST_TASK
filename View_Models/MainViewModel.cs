using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using TEST_TASK.Commands;
using TEST_TASK.Views;

namespace TEST_TASK.View_Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private CurrencyStore _currencyStore;

        public ICommand CurrencyPageButton_Click { get; }

        public ICommand DetailPageButton_Click { get; }

        public ICommand SearchPageButton_Click { get; }

        public ICommand ConvertPageButton_Click { get; }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore, CurrencyStore currencyStore)
        {
            _currencyStore = currencyStore;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            CurrencyPageButton_Click = new NavigateCommand<CurrenciesPageModel>
                (new NavigationService<CurrenciesPageModel>(navigationStore, () => new CurrenciesPageModel(_currencyStore, _navigationStore)));
            DetailPageButton_Click = new NavigateCommand<DetailPageModel>
                (new NavigationService<DetailPageModel>(navigationStore, () => new DetailPageModel(_currencyStore)));
            SearchPageButton_Click = new NavigateCommand<SearchPageModel>
                (new NavigationService<SearchPageModel>(navigationStore, () => new SearchPageModel(_currencyStore, _navigationStore)));
            ConvertPageButton_Click = new NavigateCommand<ConvertPageModel>
                (new NavigationService<ConvertPageModel>(navigationStore, () => new ConvertPageModel(_currencyStore)));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
