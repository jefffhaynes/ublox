using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.UI.Core;
using ublox.Core;
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
            var serialDeviceViewModels = serialDevices.Select(serialDevice => new SerialDeviceViewModel(serialDevice))
                .ToList();

            var newDevices = serialDeviceViewModels.Except(SerialDevices).ToList();
            var missingDevices = SerialDevices.Except(serialDeviceViewModels).ToList();
            
            foreach (var serialDevice in newDevices)
            {
                SerialDevices.Add(serialDevice);
            }

            foreach (var missingDevice in missingDevices)
            {
                SerialDevices.Remove(missingDevice);
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
                await DispatchAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Latitude = args.Latitude;
                    Longitude = args.Longitude;
                });
            };

            //await Task.Delay(TimeSpan.FromMinutes(5));
            //var test = await gps.GetPositionVelocityTimeAsync();
        }
    }
}