using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_home_library
{
    public class Security_camera : SmartDevice
    {
        //attributes (properties)

        public bool IsRecording { get; private set; }// not settable directly 
        public int StorageCapacityMB { get; }
        public int StorageUsedMB { get; private set; }

        public Security_camera(string id, string name, int storageCapacityMB) : base(id, name)
        {
            StorageCapacityMB = StorageCapacityMB;
            StorageUsedMB = 0;
        }

        public void StartRecording()
        {
            if (!IsOnline || !IsPoweredOn)
                throw new InvalidOperationException("Camera must be Online and Powered on to record");

            if (StorageUsedMB >= StorageCapacityMB)
                throw new InvalidOperationException("Storage capacity reached");

            IsRecording = true;
        }

        public void StopRecording()
        {
            IsRecording = false;
        }

        public void SimulateRecording(int minutes)
        {
            int calculatedUsage = minutes * 10;

            if (StorageUsedMB + calculatedUsage > StorageUsedMB)
                throw new InvalidOperationException("Not enough storage for recording");
            
            StorageUsedMB += calculatedUsage;
        }

        public override string GetStatus()
        {
            string recordingStatus = IsRecording ? "ECORDING" : "IDLE";
            return $"Camera {Name}: {recordingStatus}| Storage: {StorageUsedMB}/{StorageCapacityMB} MB";

        }

        public override void ApplyMode(string mode)
        {
            if (mode == "Night")
            {
                StartRecording();
            }
        }

    }
}
