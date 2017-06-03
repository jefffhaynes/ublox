using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using ublox.Utility.ViewModels;

namespace ublox.Utility
{
    public sealed partial class MainPage
    {
        private readonly MapIcon _icon = new MapIcon();

        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();

            var mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Location.png"));
            _icon.Image = mapIconStreamReference;
            _icon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            _icon.ZIndex = 0;
            Map.MapElements.Add(_icon);

            ViewModel.PositionVelocityTimeUpdated += (o, args) =>
            {
                var location = new Geopoint(new BasicGeoposition { Latitude = args.Latitude, Longitude = args.Longitude });
                Map.Center = location;
                _icon.Location = location;
            };

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await ViewModel.RefreshDevicesAsync();
        }

        public ViewModel ViewModel { get; }
    }
}
