namespace Ovning_5_Garage;

public class GarageHandler
{
    Garage<Vehicle> parking;

    public GarageHandler(string name, uint capacity)
    {
        parking = new(name, capacity);
    }

    public bool ParkVehicle(Vehicle v)
    {
        return parking.ParkVehicle(v);
    }

    public bool RemoveVehicle(string id)
    {
        return parking.RemoveVehicle(id);
    }

    public bool FindVehicle(string id)
    {
        var (found, index) = parking.FindVehicle(id);
        if (found)
            return true;
        return false;
    }

    public IEnumerable<Vehicle> ListVehicles()
    {
        return parking;
    }

    public IEnumerable<IGrouping<string, Vehicle>> ListVehicleTypes()
    {
        return parking.GetVehicleTypes();
    }

    public void Seed()
    {
        parking.ParkVehicle(new Car("123qwe", "#ffffff", 4, "Volvo", 5));
        parking.ParkVehicle(new Car("543qwe", "#ff0", 4, "Volvo", 5));
        parking.ParkVehicle(new Motorcycle("321ewq", "#123", 2, "Yamaha", 54));
    }
}
