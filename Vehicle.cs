namespace Ovning_5_Garage;

public abstract class Vehicle
{
    string Brand { get; }
    string Id { get; }

    public Vehicle(string brand, string id)
    {
        Brand = brand;
        Id = id;
    }

    public override string ToString()
    {
        return $"{Brand} - {Id}";
    }
}
