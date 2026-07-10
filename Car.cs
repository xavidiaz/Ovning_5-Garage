namespace Ovning_5_Garage;

public class Car : Vehicle
{
    public uint NumberOfDoors { get; }

    public Car(
        string registrationNumber,
        string color,
        uint numberOfWheels,
        string brand,
        uint numberOfDoors
    )
        : base(registrationNumber, color, numberOfWheels, brand)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {NumberOfDoors} doors ";
    }
}
