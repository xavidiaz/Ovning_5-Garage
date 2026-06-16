namespace Ovning_5_Garage;

public class Car : Vehicle
{
    uint NumberOfDoors { get; }

    public Car(string brand, string id, string color, uint numberOfWheels, uint numberOfDoors)
        : base(brand, id, color, numberOfWheels)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {NumberOfDoors} doors.";
    }
}
