using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smart_home_library
{
    public class Smart_Thermostat : SmartDevice
    {
        //attributes (properties)
        
        public int Temperature { get; private set; }


        public Smart_Thermostat(string id, string name) : base(id, name) { }

        public void SetTemperature(int temp)
        {
            if (!IsPoweredOn) throw new InvalidOperationException("Power is off");
            if ( temp < 50 || temp > 90) throw new ArgumentException("Temp 50-90");
            Temperature = temp;
        }

        //this method is SetTemperature if powered on allow method to run and set temp range from 50 -90

        public override string GetStatus() => 
            $" Thermostat {Name}: { (IsPoweredOn ? "On" : "Off")}, Current Temp: {Temperature}F";

        public override void ApplyMode(string mode)
        {
            if (mode == "Night" && IsPoweredOn) Temperature = 65;
        }
    }
}
