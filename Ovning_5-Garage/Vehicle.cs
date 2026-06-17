//
namespace Ovning_5_Garage;

public abstract class Vehicle : IVehicle
{
    public string Brand { get; }
    public string Id { get; }
    public string Color { get; }
    private uint _numerOfWheels;
    public uint NumerOfWheels
    {
        get => _numerOfWheels;
        init =>
            _numerOfWheels =
                value > 0 ? value : throw new ArgumentException("Wheels must be greater than 0.");
    }

    public Vehicle(string brand, string id, string color, uint numberOfWheels)
    {
        Brand = brand;
        Id = id;
        Color = color;
        NumerOfWheels = numberOfWheels;
    }

    public override string ToString()
    {
        return $"{Brand} - {Id}";
    }
}
