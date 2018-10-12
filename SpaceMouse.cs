using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace SpaceMouse_HidLibrary
{
    public class SpaceMouse
    {
        private static HidDevice _device;
        private readonly UpdateProcessor _updateProcessor = new UpdateProcessor();

        public SpaceMouse()
        {
            _device = HidDevices.Enumerate(0x046d, 0xc62b).FirstOrDefault();
            _device.OpenDevice();
            _device.MonitorDeviceEvents = true;
            _device.ReadReport(OnReport);
        }

        private void OnReport(HidReport report)
        {
            var updates = _updateProcessor.ProcessUpdate(report);
            foreach (var update in updates)
            {
                Console.WriteLine($"Type: {update.BindingType}, Index: {update.Index}, Value: {update.Value}");
            }
            _device.ReadReport(OnReport);
        }
    }
}
