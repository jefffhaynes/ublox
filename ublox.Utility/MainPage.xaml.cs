using Windows.UI.Xaml;
using ublox.Utility.ViewModels;

namespace ublox.Utility
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await ViewModel.RefreshDevicesAsync();
        }

        public ViewModel ViewModel { get; }
    }
}
