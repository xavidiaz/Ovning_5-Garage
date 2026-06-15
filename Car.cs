namespace Ovning_5_Garage;

public class Car : Vehicle
{
    uint NumberOfDoors { get; }

    public Car(string brand, string id, uint numberOfDoors)
        : base(brand, id)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {NumberOfDoors} doors.";
    }
}
