namespace Ovning_5_Garage;

class Car : Vehicle
{
    uint NumberOfDoors { get; set; }

    public Car(string brand, uint id)
        : base(brand, id) { }

    public void SetNumberOfDoors(uint numberOfDoors)
    {
        NumberOfDoors = numberOfDoors;
    }
}
