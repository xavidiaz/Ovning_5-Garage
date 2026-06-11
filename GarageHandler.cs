namespace Ovning_5_Garage;

public class GarageHandler
{
    Garage<Vehicle>? Garage { set; get; }

    public void CreateGarage(string name, uint capacity)
    {
        Garage = new Garage<Vehicle>(name, capacity);
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        Garage.ParkVehicle(vehicle);
    }

    public void UnparkVehicle(uint id)
    {
        Garage.UnparkVehicle(id);
    }

    public void FindVehicle(uint id)
    {
        Garage.FindVehicle(id);
    }

    public IEnumerable<Vehicle> ListVehicles()
    {
        return Garage.VehiclesList;
    }

    public IEnumerable<IGrouping<string, Vehicle?>> ListVehiclesType()
    {
        return Garage.VehicleTypes;
    }

    public void SearchVehicles()
    {
        Console.WriteLine("Hello from SearchVehicles! Future implementation");
    }

    public void SeedGarage()
    {
        Garage.Seed();
    }
}
