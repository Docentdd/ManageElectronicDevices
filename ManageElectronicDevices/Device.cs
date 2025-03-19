namespace ManageElectronicDevices;

public interface Device
{
     string Id { get; set; }
     string Name { get; set; }
     bool isTurnedOn { get; set; }

     
}