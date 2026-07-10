namespace Ovning_5_Garage;

public class Motorcycle : Vehicle
{
    public uint HandlebarWidth { get; }

    public Motorcycle(
        string registrationNumber,
        string color,
        uint numberOfWhheels,
        string brand,
        uint handlebarWidth
    )
        : base(registrationNumber, color, numberOfWhheels, brand)
    {
        HandlebarWidth = handlebarWidth;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, handlebarWidth: {HandlebarWidth}";
    }
}
