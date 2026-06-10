namespace Ovning_5_Garage;

class Motorcicle : Vehicle
{
    uint HandleBarWidth { get; set; }

    public Motorcicle(string brand, uint id)
        : base(brand, id) { }

    public void SetHandleBarWidth(uint handleBarWidth)
    {
        HandleBarWidth = handleBarWidth;
    }
}
