using System.Text.RegularExpressions;

namespace ManageElectronicDevices;

public abstract class Device
{
     public string Id { get; set; }
     public string Name { get; set; }
     public bool IsTurnedOn { get; set; }

     public Device(string id, string name, bool isTurnedOn)
     {
         Id = id;
         Name = name;
         IsTurnedOn = isTurnedOn;
     }

     public Device()
     {
     }
     public virtual bool TurnOff()
     {
         IsTurnedOn = false;
         return IsTurnedOn;
     }

     public virtual void TurnOn()
     {
         
     }
    
}

public class SmartWatch : Device, IPowerNotification
{
    private int _percentage;
    public SmartWatch(string id, string name, bool isTurnedOn, int percentage) : base(id, name, isTurnedOn)
    {
         _percentage = percentage;
    }

    public override string ToString()
    {
        return $"{Id} - {Name} - {IsTurnedOn} - {_percentage}";
    }

    public override void TurnOn()
    {
        if (BatteryPercentage <= 11)
        {
            Console.WriteLine(_percentage + "- your percentage (subtract 10%)");
        }
        IsTurnedOn = true;
        _percentage-= 10;
        Console.WriteLine($"{_percentage} in the {Name}");
        
    }

    public int BatteryPercentage
    {
        get => _percentage;
        set
        {
            Console.WriteLine($"{_percentage} - your percentage {Name} ");
            if (_percentage < 0 || _percentage > 100)
            {
                throw new ArgumentOutOfRangeException("Battery percentage must be between 0 and 100");
            }

            if (_percentage < 20)
            {
                NotifyPower();
            }
        }
    }

    public string BatteryLevel { get; set; }

    public void NotifyPower()
    {
        throw new Exception("This device " + Name + " need to be plugged in");
    }
}
public interface IPowerNotification
{
    void NotifyPower();
}

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException(string message) : base(message)
    {
    }
}
// -----------
public class PersonalComputer : Device, NotifyEmptySystemException
{
    public string OperationSystem { get; set; }
    public string OperatingSystem { get; set; }

    public PersonalComputer(string id, string name, bool isTurnedOn, string operationSystem) : base(id, name, isTurnedOn)
    {
        OperationSystem = operationSystem;
    }

    public override string ToString()
    {
        return $"{Id} - {Name} - {IsTurnedOn} - {OperationSystem}";
    }

    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(OperationSystem))
        {
            NotifyEmptySystemException();
        }
        IsTurnedOn = true;
    }
    public void NotifyEmptySystemException()
    {
        throw new Exception("This device " + Name + " need to have operation system");
    }
}
// I'm suppose that you mean to do that like that 
// I hope that will not a huge mistake. That way to create a new exception was introduced in every device
public interface NotifyEmptySystemException
{
    void NotifyEmptySystemException();
}

public class EmptySystemException : Exception
{
    public EmptySystemException(string message) : base(message)
    {
    }
}
//--------------
public class EmbeddedDevice : Device, ConnectionException, ArgumentException
{
    private string _ip;
    private string _networkName;
    public EmbeddedDevice(string id, string name, string ip, string networkName) : base(id, name, false)
    {
        _ip = ip;
        _networkName = networkName;
    }
    

    public string IpAddress { get; set; }
    public string Network { get; set; }
    

    public override void TurnOn()
    {
        if (!_networkName.Contains("MD Ltd."))
        {
            NotifyConnectionException();
        }
        IsTurnedOn = true;
    }
    public override string ToString()
    {
        return $"{Id} - {Name} - {IsTurnedOn} - {_ip} - {_networkName}";
    }
    public void CheckTheIP()
    {
        string pattern =
            @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        if (!Regex.IsMatch(_ip, pattern))
        {
            throw new ArgumentException2("This device " + Name + " needs to have a correct IP address.");
        }
    }
    public void NotifyConnectionException()
    {
        throw new Exception("This device " + Name + " need to use MD Ltd. network");
    }
    
    public void ArgumentException()
    {
        throw new Exception("This device " + Name + " need to have correct IP address");
    }
    
}
// for network Md Ltd.
public interface ConnectionException
{
    void NotifyConnectionException();
}
public class ConnectionException2 : Exception
{
    public ConnectionException2(string message) : base(message)
    {
    }
}
// for IP
public interface ArgumentException
{
    void ArgumentException();
}
public class ArgumentException2 : Exception
{
    public ArgumentException2(string message) : base(message)
    {
    }
}


