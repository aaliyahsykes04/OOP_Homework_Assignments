using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_vs_inheretence
{
    public class DeviceGroup
    {
        private List<Smart_device> devices = new();

        //methods 
        public void AddDevice(Smart_device device)
        {
            if (device == null)
                throw new ArgumentNullException("Device can not be null.");
            if (devices.Contains(device))
                devices.Add(device);
            else
                throw new ArgumentException("Device already exists in the group.");
        }

        public void TurnOffAllDevices()
        {
            foreach (var device in devices)
            {
                device.TurnOff();
            }
        }

        public void PrintStatuses()
        {
            foreach (var device in devices)
            {
                Console.WriteLine($"{device.Name} is {device.GetStatus()}");
            }
        }


    }
}
