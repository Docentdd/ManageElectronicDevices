using System;
using System.Collections.Generic;

namespace ManageElectronicDevices
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<Device> devices = new List<Device>
            // {
            //     new SmartWatch("SW001", "Smartwatch 1", false, 50),
            //     new SmartWatch("SW002", "Smartwatch 2", true, 11),
            //     new PersonalComputer("P001", "LinuxPC", false, "Linux Mint"),
            //     new PersonalComputer("P002", "ThinkPad T440", false, "null"),
            //     new EmbeddedDevice("ED001", "Embedded Device 1", false, "192.168.0.1", "MD Ltd. Network"),
            //     new EmbeddedDevice("ED002", "Embedded Device 2", false, "256.256.256.256", "Other Network")
            //
            // };
            DeviceManager manager =
                new DeviceManager(
                    "/Users/dmytronakonechnyi/Downloads/input.txt");
          
                Console.WriteLine(manager.Devices.Count);
                Console.WriteLine("Thoose devices we have -> ");
                manager.ShowAllDevices();
                // Add the devices
                manager.AddDevice(new SmartWatch("SW003", "Smartwatch 3", false, 50));
                Console.WriteLine("After the adding the device, amount of the devices are -> " + manager.Devices.Count);
                // Remove a device
                manager.RemoveDevice("SW-1");
                Console.WriteLine(
                    "After the removing the device, amount of the devices are -> " + manager.Devices.Count);
                // Edit a device
                manager.EditDevice("SW03", new SmartWatch("SW002", "Smartwatch 2", true, 11));
                Console.WriteLine("After the editing the device, amount of the devices are -> " +
                                  manager.Devices.Count);
                // Turn on a device
                manager.TurnOnDevice("SW003");
                manager.ShowAllDevices();
                Console.WriteLine("After the turning on the device, amount of the devices are -> " +
                                  manager.Devices.Count);
                // Turn off devices
                manager.TurnOffDevice("SW003");
                manager.ShowAllDevices();

                manager.SaveDataToFile("/Users/dmytronakonechnyi/Downloads/inputcopy.txt");
            }
            

            // foreach (var device in devices)
            // {
            //     try
            //     {
            //         Console.WriteLine(device.Name);
            //         device.TurnOn();
            //         Console.WriteLine($"{device.Name} is turned on.");
            //     }
            //     catch (EmptyBatteryException ex)
            //     {
            //         Console.WriteLine(ex.Message);
            //     }
            //     catch (EmptySystemException exs)
            //     {
            //         Console.WriteLine(exs.Message);
            //     }
            //     catch (ArgumentException2 ex)
            //     {
            //         Console.WriteLine(ex.Message);
            //     }
            //     catch (ConnectionException2 ex)
            //     {
            //         Console.WriteLine(ex.Message);
            //     }
            // }
        }
    }