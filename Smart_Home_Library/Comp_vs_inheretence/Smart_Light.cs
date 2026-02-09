using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_vs_inheretence
{
    public class SmartLight : Smart_device
    {
        //properties
        public int _brightness { get; private set; } // 0 to 100

        public SmartLight(string deviceId, string name) : base(deviceId,name)

        public void SetBrightness(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Brightness must be between 0 - 100");
            if (!Power.IsPoweredOn)
                throw new InvalidOperationException("Cannot set brightness: Light is powered off.");

            _brightness = value;

        }

        public override string GetStatus()
        {
            string powerStatus = Power.IsPoweredOn ? "On" : "Off";
            string onlineStatus = Power.IsOnline ? "Online" : "Offline";
            return $"[Light] ID: {DeviceId}, Name {Name} , Status: {onlineStatus}/{powerStatus},{_brightness}%";
        }
    }

}
