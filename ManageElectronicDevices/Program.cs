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
                new SmartWatch("SW002", "Smartwatch 2", true, 11),
                new PersonalComputer("P001", "LinuxPC", false, "Linux Mint"),
                new PersonalComputer("P002", "ThinkPad T440", false, "null"),
                new EmbeddedDevice("ED001", "Embedded Device 1", false, "192.168.0.1", "MD Ltd. Network"),
                new EmbeddedDevice("ED002", "Embedded Device 2", false, "256.256.256.256", "Other Network")

            };

            foreach (var device in devices)
            {
                try
                {
                    Console.WriteLine(device.Name);
                    device.TurnOn();
                    Console.WriteLine($"{device.Name} is turned on.");
                }
                catch (EmptyBatteryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (EmptySystemException exs)
                {
                    Console.WriteLine(exs.Message);
                }
                catch (ArgumentException2 ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ConnectionException2 ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}