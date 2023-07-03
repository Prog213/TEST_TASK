using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TEST_TASK.Commands;
using TEST_TASK.Views;

namespace TEST_TASK.View_Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ICommand CurrencyPageButton_Click { get; }

        public ICommand DetailPageButton_Click { get; }

        public ICommand SearchPageButton_Click { get;}

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            CurrencyPageButton_Click = new NavigateCommand<CurrenciesPageModel>
                (new NavigationService<CurrenciesPageModel>( navigationStore, ()=> new CurrenciesPageModel()));
            DetailPageButton_Click = new NavigateCommand<DetailPageModel>
                (new NavigationService<DetailPageModel>(navigationStore, () => new DetailPageModel()));
            SearchPageButton_Click = new NavigateCommand<SearchPageModel>
                (new NavigationService<SearchPageModel>(navigationStore, () => new SearchPageModel()));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }




        //public ICommand MainPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new MainPage()));

        //public ICommand DetailPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new DetailPage()));

        //public ICommand SearchPageButton_Click => new RelayCommand(() => NavigationStore.NavigateCommand.Execute(new SearchPage()));
    }
}
