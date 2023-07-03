using System;

namespace TEST_TASK.View_Models
{
    public class NavigationService<TViewmodel>
    where TViewmodel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewmodel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewmodel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
