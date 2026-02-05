using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Smart_home_library
{
    public class Hub
    {
        private List<SmartDevice> _devices = new();

        public void AddDevice(SmartDevice device)
        {
            if (device == null) throw new ArgumentException();
            {
                if (device == null) throw new ArguementNullException();
                if (_devices.Any(d => d.DeviceId == device.DeviceId)) throw new ArgumentException("Duplicate ID.");
                _devices.Add(device);
            }

        public void RemoveDevice(string deviceId) => _devices.RemoveAll(d.DeviceId == deviceId);

        public void TurnOffAll() => _devices.ForEach(d => d.TurnOff());

        public void PrintAllStatuses()
        { 
            foreach (var d in _devices) Console.WriteLine(d.GetStatus());

        }

        public void ApplyModeToAll(string mode)
        {
            foreach (var d in _devices) d.ApplyMode(mode);

        }

    
    }
}
