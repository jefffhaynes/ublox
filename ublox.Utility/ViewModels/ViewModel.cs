using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Enumeration;
using Windows.Devices.Geolocation;
using Windows.Devices.SerialCommunication;
using Windows.UI.Core;
using ublox.Core;
using ublox.Core.Messages.Enums;
using ublox.Universal;

namespace ublox.Utility.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private SerialDeviceViewModel _selectedSerialDevice;
        private double _latitude;
        private double _longitude;
        public ObservableCollection<SerialDeviceViewModel> SerialDevices { get; } = new ObservableCollection<SerialDeviceViewModel>();

        private Device _gps;
        private Geopoint _location;
        private GnssFixType _fixType;
        private DateTime _time;
        private TimeSpan _timeAccuracy;
        private uint _satelliteCount;

        public event EventHandler<PositionVelocityTimeEventArgs> PositionVelocityTimeUpdated;

        public ViewModel()
        {
            ConnectCommand = new RelayCommand(ConnectAsync);
        }

        public SerialDeviceViewModel SelectedSerialDevice
        {
            get => _selectedSerialDevice;

            set
            {
                if (Equals(value, _selectedSerialDevice)) return;
                _selectedSerialDevice = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConnectCommand { get; }

        public async Task RefreshDevicesAsync()
        {
            var devices = await DeviceInformation.FindAllAsync(SerialDevice.GetDeviceSelector());
            var serialDeviceTasks = devices.Select(device => SerialDevice.FromIdAsync(device.Id).AsTask());
            var serialDevices = await Task.WhenAll(serialDeviceTasks);
            var validSerialDevices = serialDevices.Where(device => device != null);
            var serialDeviceViewModels = validSerialDevices.Select(serialDevice => new SerialDeviceViewModel(serialDevice))
                .ToList();

            var newDevices = serialDeviceViewModels.Except(SerialDevices).ToList();
            var missingDevices = SerialDevices.Except(serialDeviceViewModels).ToList();
            
            foreach (var serialDevice in newDevices)
            {
                SerialDevices.Add(serialDevice);
                serialDevice.DataBits = 8;
                serialDevice.Handshake = SerialHandshake.None;
                serialDevice.Parity = SerialParity.None;
                serialDevice.StopBits = SerialStopBitCount.One;
            }

            foreach (var missingDevice in missingDevices)
            {
                SerialDevices.Remove(missingDevice);
            }
        }

        public Geopoint Location
        {
            get => _location;

            set
            {
                if (Equals(value, _location)) return;
                _location = value;
                OnPropertyChanged();
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value.Equals(_latitude)) return;
                _latitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                if (value.Equals(_longitude)) return;
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public GnssFixType FixType
        {
            get => _fixType;
            set
            {
                if (value == _fixType) return;
                _fixType = value;
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                if (value.Equals(_time)) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan TimeAccuracy
        {
            get => _timeAccuracy;
            set
            {
                if (value.Equals(_timeAccuracy)) return;
                _timeAccuracy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimeString));
            }
        }

        public string TimeString => Time.ToString("M/d/yyyy HH:mm:ss.ffff") + " ± " + TimeAccuracy.ToString("g");

        public uint SatelliteCount
        {
            get => _satelliteCount;
            set
            {
                if (value == _satelliteCount) return;
                _satelliteCount = value;
                OnPropertyChanged();
            }
        }

        private async void ConnectAsync()
        {
            if (SelectedSerialDevice == null)
            {
                return;
            }

            var serialWrapper = new SerialDeviceWrapper(SelectedSerialDevice.SerialDevice);
            _gps = new Device(serialWrapper);

            _gps.PositionVelocityTimeUpdated += async (sender, args) =>
            {
                await DispatchAsync(CoreDispatcherPriority.High, () =>
                {
                    Time = args.DateTime;
                    TimeAccuracy = args.TimeAccuracy;
                    Latitude = args.Latitude;
                    Longitude = args.Longitude;
                    FixType = args.FixType;
                    SatelliteCount = args.SatelliteCount;
                    PositionVelocityTimeUpdated?.Invoke(this, args);
                });
            };

            await _gps.InitializeAsync();

            await _gps.ConfigureMessagesAsync(MessageId.NAV_PVT, null, null, null, 1, null);
            await _gps.ConfigureMessagesAsync(MessageId.NAV_SVINFO, null, null, null, 1, null);
        }
    }
}