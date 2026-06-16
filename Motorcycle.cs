namespace Ovning_5_Garage;

public class Motorcycle : Vehicle
{
    uint HandlebarWidth { get; }

    public Motorcycle(
        string brand,
        string id,
        string color,
        uint numberOfWheels,
        uint handlebarWidth
    )
        : base(brand, id, color, numberOfWheels)
    {
        HandlebarWidth = handlebarWidth;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, handlebar width: {HandlebarWidth}.";
    }
}
