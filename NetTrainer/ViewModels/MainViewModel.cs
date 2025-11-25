using Avalonia.Controls;
using System.Windows.Input;
using ReactiveUI;

namespace NetTrainer.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private GridLength _navigationPanelWidth = new GridLength(200);
        private string _navigationPanelIcon = "◀";
        private object _currentPage;

        public ICommand ToggleNavigationCommand { get; }

        public GridLength NavigationPanelWidth
        {
            get => _navigationPanelWidth;
            set => this.RaiseAndSetIfChanged(ref _navigationPanelWidth, value);
        }

        public string NavigationPanelIcon
        {
            get => _navigationPanelIcon;
            set => this.RaiseAndSetIfChanged(ref _navigationPanelIcon, value);
        }

        public object CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public MainViewModel()
        {
            ToggleNavigationCommand = ReactiveCommand.Create(ToggleNavigation);
            CurrentPage = "Добро пожаловать!";
        }

        private void ToggleNavigation()
        {
            if (_navigationPanelWidth.Value > 0)
            {
                NavigationPanelWidth = new GridLength(0);
                NavigationPanelIcon = "▶";
            }
            else
            {
                NavigationPanelWidth = new GridLength(200);
                NavigationPanelIcon = "◀";
            }
        }
    }
}