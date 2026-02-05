using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_home_library
{
    internal class Smart_light : SmartDevice
    {
        //attribute (properties)

        public int Brightness { get; private set; }
        public string Color { get; private set; }

        public Smart_light(string id, string name) : base(id, name) { }

        public void SetBrightness(int value)
          {
            if (!IsPoweredOn) throw new InvalidOperationException("Power is off");
            if (value < 0 || value > 100) throw new ArgumentException("Range 0-100");
            Brightness = value;
          }
            // this method is called SetBrightness
            // if powered on is false then throw "power is off"
            // brightness --> value between range 1-100

         public override string GetStatus() => $"Light {Name}: {(IsPoweredOn ? "On" : "Off")}, {Brightness}% ,{Color}";

         public override void ApplyMode(string mode)
            {
                 if (mode == "Night" && IsPoweredOn) Brightness = 10;
            }
        }
}
