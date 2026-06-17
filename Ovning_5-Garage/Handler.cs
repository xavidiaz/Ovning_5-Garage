//
namespace Ovning_5_Garage;

public class Handler
{
    private Garage<Vehicle>? _garage;

    public void CreateGarage(string name, uint capacity)
    {
        _garage = new Garage<Vehicle>(name, capacity);
    }

    public void ParkVehicle(Vehicle? vehicle)
    {
        if (_garage == null)
            return;
        if (vehicle == null)
            return;

        _garage.ParkVehicle(vehicle);
    }

    public void UnparkVehicle(string id)
    {
        if (_garage == null)
            return;

        _garage.UnparkVehicle(id);
    }

    public (bool, int) FindVehicle(string id)
    {
        if (_garage == null)
            return (false, -1);
        return _garage.FindVehicle(id);
    }

    public IEnumerable<Vehicle> ListVehicles()
    {
        if (_garage == null)
            return Enumerable.Empty<Vehicle>();
        return _garage;
    }

    public IEnumerable<IGrouping<string, Vehicle?>> ListVehicleTypes()
    {
        if (_garage == null)
            return Enumerable.Empty<IGrouping<string, Vehicle?>>();
        return _garage.VehicleTypes;
    }

    public IEnumerable<Vehicle> SearchVehicles(Func<Vehicle, bool> filter)
    {
        if (_garage == null)
            return Enumerable.Empty<Vehicle>();
        return _garage.SearchVehicles(filter);
    }

    public void SeedGarage()
    {
        if (_garage == null)
            return;

        _garage.Seed();
    }
}
