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
     public abstract bool TurnOff();
     public abstract void TurnOn();
    
}

public class SmartWatch : Device, IPowerNotification
{
    private int _percentage;
    public SmartWatch(string id, string name, bool isTurnedOn, int percentage) : base(id, name, isTurnedOn)
    {
        BatteryPercentage = percentage;
    }

    public override bool TurnOff()
    {
        IsTurnedOn = false;
        return IsTurnedOn;
    }

    public override void TurnOn()
    {
        if (BatteryPercentage <= 11)
        {
            Console.WriteLine(_percentage + "- your percentage (subtract 10%)");
        }
        IsTurnedOn = true;
        BatteryPercentage-= 10;
    }

    public int BatteryPercentage
    {
        get => _percentage;
        set
        {
            if (_percentage < 0 || _percentage > 100)
            {
                throw new ArgumentOutOfRangeException("Battery percentage must be between 0 and 100");
            }

            if (BatteryPercentage < 20)
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