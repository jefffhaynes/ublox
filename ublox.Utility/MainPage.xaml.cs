using System;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using ublox.Core.Messages.Enums;
using ublox.Utility.ViewModels;

namespace ublox.Utility
{
    public sealed partial class MainPage
    {
        private readonly MapIcon _icon = new MapIcon();
        private readonly MapPolygon _cep = new MapPolygon();

        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();

            SetupMap();

            ViewModel.PositionVelocityTimeUpdated += (o, args) =>
            {
                if (args.FixType == GnssFixType.NoFix)
                {
                    _icon.Visible = false;
                    _cep.Visible = false;
                    return;
                }

                _icon.Visible = true;
                _cep.Visible = true;

                var basicGeo = new BasicGeoposition {Latitude = args.Latitude, Longitude = args.Longitude};
                var location = new Geopoint(basicGeo);
                Map.Center = location;
                _icon.Location = location;
                
                var cepPoints = location.GetCirclePoints(args.HorizontalAccuracyEstimate.TotalMeters);
                _cep.Path = new Geopath(cepPoints.Select(p => p.Position));

                if (!Map.MapElements.Contains(_cep))
                {
                    Map.MapElements.Add(_cep);
                }
            };

            Loaded += OnLoaded;
        }

        private void SetupMap()
        {
            var mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Location.png"));
            _icon.Image = mapIconStreamReference;
            _icon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            _icon.ZIndex = 0;
            Map.MapElements.Add(_icon);
            
            _cep.FillColor = (Color)Application.Current.Resources["SystemListAccentHighColor"];
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await ViewModel.RefreshDevicesAsync();
        }

        public ViewModel ViewModel { get; }
    }
}
