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
                NotifyPower(_percentage);
            }
        }
    }

    public void NotifyPower(int percentage)
    {
        throw new Exception("This device " + Name + " need to be plugged in");
    }
}
public interface IPowerNotification
{
    void NotifyPower(int percentage);
}

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException(string message) : base(message)
    {
    }
}

public class PersonalComputer : Device
{
    public string OperationSystem { get; set; }

    public PersonalComputer(string id, string name, bool isTurnedOn, string operationSystem) : base(id, name, isTurnedOn)
    {
        OperationSystem = operationSystem;
    }
    

    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(OperationSystem))
        {
            NotifyEmptySystemException("This device " + Name + " need to have operation system");
        }
        IsTurnedOn = true;
    }
    public void NotifyEmptySystemException(string message)
    {
        throw new Exception("This device " + Name + " need to have operation system");
    }
}

public class EmptySystemException : Exception
{
    public EmptySystemException(string message) : base(message)
    {
    }
}

