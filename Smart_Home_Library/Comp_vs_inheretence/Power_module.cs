using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_vs_inheretence
{
    public class Power_module
    {

        //properties
        public bool IsOnline { get; private set; }
        //get and private set means we are getting the value from outside the class but can only set it from within the class
        public bool IsPoweredOn { get; private set; }


        //methods , verbs, behaviors
        public void SetOnlne(bool online)
        {
            IsOnline = online;
            if (!online) IsPoweredOn = false;
            // to set Online , IsOnline is equal to online, if online is false than powerdOn is also false
        }

        public void TurnOn()
        {
            if (!IsOnline)
                throw new InvalidOperationException("Cannot turn on: Device is offline.");

            IsPoweredOn = true;
            // if isonline is false then device can not be turned on 
            // else IsPoweredOn is true
        }

        public void TurnOff()
        {
            IsPoweredOn = false;
        }

        //device turns off when device is powered off

    }
}
