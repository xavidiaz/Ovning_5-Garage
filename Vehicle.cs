namespace Ovning_5_Garage;

public abstract class Vehicle : IVehicle
{
    public string Brand { get; }
    public uint Id { get; }

    public Vehicle(string brand, uint id)
    {
        Brand = brand;
        Id = id;
    }

    public override string ToString()
    {
        return $"{Brand} - {Id}";
    }
}
