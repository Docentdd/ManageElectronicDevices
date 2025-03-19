using ManageElectronicDevices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace ManageElectronicDevices.Tests
    {
        [TestClass]
        public class EmbeddedDeviceTest
        {
            [TestMethod]
            public void TestTurnOnWithValidNetwork()
            {
                // Arrange
                var device = new EmbeddedDevice("ED001", "Embedded Device 1", false, "192.168.0.1", "MD Ltd. Network");
    
                // Act
                device.TurnOn();
    
                // Assert
                Assert.IsTrue(device.IsTurnedOn);
            }
    
            [TestMethod]
            [ExpectedException(typeof(ConnectionException), "This device Embedded Device 2 needs to use MD Ltd. network")]
            public void TestTurnOnWithInvalidNetwork()
            {
                // Arrange
                var device = new EmbeddedDevice("ED002", "Embedded Device 2", false, "192.168.0.1", "Other Network");
    
                // Act
                device.TurnOn();
            }
            [TestMethod]
            [ExpectedException(typeof(ArgumentException), "This device Embedded Device 2 needs to have a correct IP address")]
            public void TestCheckTheIPWithInvalidIP()
            {
                // Arrange
                var device = new EmbeddedDevice("ED002", "Embedded Device 2", false, "256.256.256.256", "MD Ltd. Network");
    
                // Act
                device.CheckTheIP();
            }
        }
    }