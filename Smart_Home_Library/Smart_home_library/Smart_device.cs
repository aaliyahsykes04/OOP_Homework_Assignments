using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_home_library
{
    //attributes (properties)
    public abstract class SmartDevice
    // abstract class --> exist only to be inherited from
    {
        public string DeviceId { get; }
        public string Name { get; private set; }
        public bool IsOnline { get; private set; }
        public bool IsPoweredOn { get; private set; }

        //constructor
        protected SmartDevice(string deviceId, string name)
        {
            DeviceId = id;
            Name = name;

        }

        //methods (behaviors/ verbs)
        // virtual --> says that this method can be overridden by a child class
        // void --> means the method performs an action but doesn't return any data (number or string) back to you 

        public void SetOnline(bool online) => IsOnline = online;
        // if method SetOnline is called with true parameter, IsOnline becomes true

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name cannot be emptry.");
            Name = newName;
        }
        //if string entered in Rename method is null, throw exception, newName is assigned to Namepublic void SetOnline(bool online) => IsOnline = online;public void SetOnline(bool online) => IsOnline = online;public void SetOnline(bool online) => IsOnline = online;public void SetOnline(bool online) => IsOnline = online;public void SetOnline(bool online) => IsOnline = online;

        public virtual void TurnOn()
        {
            if (!IsOnline) throw new InvalidOperationException("Device is offline");
            IsPoweredOn = true;
        }
        // if IsOnliine is false throw an exception, isturnedon is true

        public virtual void TurnOff() =>   IsPoweredOn = false;
        // this powers off

        
        public abstract string GetStatus();
        //abstract --> means that the method has no body 
        //force class to return value

        public virtual void ApplyMode(string mode) { }
        //

    }

}
