namespace ManageElectronicDevices;

public class DeviceManager
    
{
    public List<Device> Devices = new List<Device>();

    public DeviceManager(string filePath)
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                try
                {
                    Console.WriteLine(line);
                    var parts = line.Split(',');
                    if (parts.Length > 0)
                    {
                        if (line.StartsWith("SW"))
                        {
                            Devices.Add(new SmartWatch(parts[0], parts[1], bool.Parse(parts[2]), int.Parse(parts[3])));
                        }
                        else if (line.StartsWith("P"))
                        {
                            Devices.Add(new PersonalComputer(parts[0], parts[1], bool.Parse(parts[2]), parts[3]));
                            
                        }
                        else if (line.StartsWith("ED"))
                        {
                            Devices.Add(new EmbeddedDevice(parts[0], parts[1], parts[2], parts[3]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error parsing line: {line}. Exception: {e.Message}");
                }
            }
        }

// Other methods (AddDevice, RemoveDevice, EditDevice, etc.) remain unchanged
    }
    public void AddDevice(Device device)
    {
        Devices.Add(device);
    }

    public void RemoveDevice(string id)
    {
        Devices.RemoveAll(d => d.Id == id);
    }

    public void EditDevice(string id, Device updatedDevice)
    {
        var index = Devices.FindIndex(d => d.Id == id);
        if (index != -1)
        {
            Devices[index] = updatedDevice;
        }
    }

    public void TurnOnDevice(string id)
    {
        var device = Devices.Find(d => d.Id == id);
        device.TurnOn();
    }

    public void TurnOffDevice(string id)
    {
        var device = Devices.Find(d => d.Id == id);
        device?.TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in Devices)
        {
                Console.WriteLine(device.ToString());
                
        }
    }

    public void SaveDataToFile(string filePath)
    {
        var lines = new List<string>();
        foreach (var device in Devices)
        {
            if (device is SmartWatch sw)
            {
                lines.Add($"{sw.Id},{sw.Name},{sw.IsTurnedOn},{sw.BatteryLevel}");
            }
            else if (device is PersonalComputer pc)
            {
                lines.Add($"{pc.Id},{pc.Name},{pc.IsTurnedOn},{pc.OperatingSystem}");
            }
            else if (device is EmbeddedDevice ed)
            {
                lines.Add($"{ed.Id},{ed.Name},{ed.IsTurnedOn},{ed.IpAddress},{ed.Network}");
            }
        }
        File.WriteAllLines(filePath, lines);
    }

    public void NotifyEmptySystemException()
    {
        Console.WriteLine($"No Operation System found");
    }
}
