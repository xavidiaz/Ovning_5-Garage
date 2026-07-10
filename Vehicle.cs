namespace Ovning_5_Garage;

public interface IVehicle
{
    string RegistrationNumber { get; }
    string Color { get; }
    uint NumberOfWheels { get; }
    string Brand { get; }

    string ToString();
}

public abstract class Vehicle : IVehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public uint NumberOfWheels { get; }
    public string Brand { get; }

    public Vehicle(string registrationNumber, string color, uint numberOfWhhels, string brand)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWhhels;
        Brand = brand;
    }

    public override string ToString()
    {
        return $"{Brand} ({RegistrationNumber}), {Color}, {NumberOfWheels} hjul";
    }
}
