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
         
            var pc = new PersonalComputer("P001", "LinuxPC", false, "Linux Mint");

      
            pc.TurnOn();

       
            Assert.IsTrue(pc.IsTurnedOn);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptySystemException))]
        public void TestTurnOnWithoutOS()
        {
          
            var pc = new PersonalComputer("P002", "ThinkPad T440", false, null);

    
            pc.TurnOn();
        }

        [TestMethod]
        public void TestTurnOff()
        {
          
            var pc = new PersonalComputer("P001", "LinuxPC", true, "Linux Mint");

           
            var result = pc.TurnOff();

         
            Assert.IsFalse(pc.IsTurnedOn);
            Assert.IsFalse(result);
        }
    }
}