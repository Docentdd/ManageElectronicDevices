using ManageElectronicDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManageElectronicDevices.Tests
{
    public class TestDevice : Device
    {
        public TestDevice(string id, string name, bool isTurnedOn) : base(id, name, isTurnedOn) { }

        public override bool TurnOff()
        {
            IsTurnedOn = false;
            return IsTurnedOn;
        }

        public override void TurnOn()
        {
            IsTurnedOn = true;
        }
    }
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void TestTurnOn()
        {
            // Arrange
            var device = new TestDevice("D1", "Test Device", false);

            // Act
            device.TurnOn();

            // Assert
            Assert.IsTrue(device.IsTurnedOn);
        }

        [TestMethod]
        public void TestTurnOff()
        {
            // Arrange
            var device = new TestDevice("D1", "Test Device", true);

            // Act
            var result = device.TurnOff();

            // Assert
            Assert.IsFalse(device.IsTurnedOn);
            Assert.IsFalse(result);
        }
    }
}