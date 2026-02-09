using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_vs_inheretence
{
    public abstract class Smart_device
    {
        // properties 
        public string DeviceId { get; }
        public string Name { get; private set; }
        public Power_module Power { get; } // composition - has a power module


        //methods , verbs, behaviors

        public Smart_device(string deviceId, string name)
        { 
            if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentException("Device ID can not be blank.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name can not be blank.");

            DeviceId = deviceId;
            Name = name;
            Power = new Power_module();
        }

        //in this method we are creating a method to rename the device and if the new name is null or empty we are throwing an exception
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("New name can not be blank.");
            Name = newName;
        }

        public virtual void SetOnline(bool online)
        {
            Power.SetOnlne(online);
        }

        public virtual void TurnOn() 
        {
            Power.TurnOn();
        }

        public virtual void TurnOff()
        {
            Power.TurnOff();
        }
        public abstract string GetStatus();




    }
}
