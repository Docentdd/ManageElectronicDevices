using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ManageElectronicDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManageElectronicDevices.Tests
{
    [TestClass]
    public class DeviceManagerTests
    {
        [TestMethod]
        public void AddDevice_ShouldAddDeviceToList()
        {
            
            var manager = new DeviceManager(string.Empty);
            var device = new SmartWatch("SW003", "Smartwatch 3", false, 50);

           
            manager.AddDevice(device);

            
            Assert.Contains(device, manager.Devices);
        }

        [TestMethod]
        public void RemoveDevice_ShouldRemoveDeviceFromList()
        {
            var manager = new DeviceManager(string.Empty);
            var device = new SmartWatch("SW003", "Smartwatch 3", false, 50);
            manager.AddDevice(device);
            
            manager.RemoveDevice("SW003");
            
            Assert.DoesNotContain(device, manager.Devices);
        }

        [TestMethod]
        public void EditDevice_ShouldUpdateDeviceInList()
        {
            
            var manager = new DeviceManager(string.Empty);
            var device = new SmartWatch("SW003", "Smartwatch 3", false, 50);
            manager.AddDevice(device);
            var updatedDevice = new SmartWatch("SW003", "Smartwatch 3 Updated", true, 75);

        
            manager.EditDevice("SW003", updatedDevice);

            
            var editedDevice = manager.Devices.Find(d => d.Id == "SW003");
            Assert.AreEqual("Smartwatch 3 Updated", editedDevice.Name);
            Assert.IsTrue(editedDevice.IsTurnedOn);



            }

        [TestMethod]
        public void TurnOnDevice_ShouldTurnOnDevice()
        {
            
            var manager = new DeviceManager(string.Empty);
            var device = new SmartWatch("SW003", "Smartwatch 3", false, 50);
            manager.AddDevice(device);

            
            manager.TurnOnDevice("SW003");

            
            Assert.IsTrue(device.IsTurnedOn);
        }

        [TestMethod]
        public void TurnOffDevice_ShouldTurnOffDevice()
        {
            
            var manager = new DeviceManager(string.Empty);
            var device = new SmartWatch("SW003", "Smartwatch 3", true, 50);
            manager.AddDevice(device);

            
            manager.TurnOffDevice("SW003");

           
            Assert.IsFalse(device.IsTurnedOn);
        }
    }
}