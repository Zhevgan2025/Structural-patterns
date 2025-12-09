using System;

interface IDevice
{
    void TurnOn();
    void TurnOff();
}

class Tv : IDevice
{
    public void TurnOn() => Console.WriteLine("TV ON");
    public void TurnOff() => Console.WriteLine("TV OFF");
}

class Remote
{
    protected IDevice device;

    public Remote(IDevice device)
    {
        this.device = device;
    }

    public virtual void TogglePower()
    {
        device.TurnOn();
    }
}
    

class AdvancedRemote : Remote
{
   public AdvancedRemote(IDevice device) : base(device) { }

    public void TurnOff()
    {
        device.TurnOff();
    }
}



