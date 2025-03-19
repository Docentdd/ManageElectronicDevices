using ManageElectronicDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManageElectronicDevices.Tests
{
    [TestClass]
    public class PersonalComputerTest
    {
        [TestMethod]
        public void TestTurnOnWithOS()
        {
            // Arrange
            var pc = new PersonalComputer("P001", "LinuxPC", false, "Linux Mint");

            // Act
            pc.TurnOn();

            // Assert
            Assert.IsTrue(pc.IsTurnedOn);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptySystemException))]
        public void TestTurnOnWithoutOS()
        {
            // Arrange
            var pc = new PersonalComputer("P002", "ThinkPad T440", false, null);

            // Act
            pc.TurnOn();
        }

        [TestMethod]
        public void TestTurnOff()
        {
            // Arrange
            var pc = new PersonalComputer("P001", "LinuxPC", true, "Linux Mint");

            // Act
            var result = pc.TurnOff();

            // Assert
            Assert.IsFalse(pc.IsTurnedOn);
            Assert.IsFalse(result);
        }
    }
}