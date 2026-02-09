using System;
using System.Collections.Generic;
using System.Text;
using static Comp_vs_inheretence.MiniSmartHomeConsole;

namespace Comp_vs_inheretence
{
    public class MiniSmartHomeConsole
    {
        public MiniSmartHomeConsole()
        {
            try
            {
                //Create a SmartLight
                SmartLight livingroomlight = new SmartLight("L001", "Living Room");
                //Create DeviceGroup to manage devices
                DeviceGroup home = new DeviceGroup();
                home.AddDevice(livingroomlight);

                //Rename the device
                livingroomlight.Rename("Living Room Lamp");

                Console.WriteLine("Successfully added device!");

                //intentional error to turnon while offline
                try
                {
                    //this should fail because TurnOn is meant to be true
                    livingroomlight.TurnOn();
                }
                catch (InvalidOperationException ex)
                {
                    //Catching the error thrown by PowerModule
                    Console.WriteLine($"Caught Expected Error:{ex.Message}");
                }
                
                Console.WriteLine("Attempting to turn on while offline");
                //set online, turn on and set brightness
                livingroomlight.SetOnline(true);
                livingroomlight.TurnOn();
                livingroomlight.SetBrightness(150);

                Console.WriteLine("Current Status");
                home.PrintStatuses();

                Console.WriteLine("Turning Off All Devices");
                home.TurnOffAllDevices();
                home.PrintStatuses();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error : {ex.Message}");
            }
        }
    }
}
