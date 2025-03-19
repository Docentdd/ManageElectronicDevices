using System;
using System.Collections.Generic;

namespace ManageElectronicDevices
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Device> devices = new List<Device>
            {
                new SmartWatch("SW001", "Smartwatch 1", false, 50),
                new SmartWatch("SW002", "Smartwatch 2", true, 11)
            };

            foreach (var device in devices)
            {
                try
                {
                    Console.WriteLine(device.Name);
                    device.TurnOn();
                    Console.WriteLine($"{device.Name} is turned on." );
                }
                catch (EmptyBatteryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}