namespace Ovning_5_Garage;

interface IGarage<T>
    where T : IVehicle
{
    string Name { get; }
    uint Capacity { get; }
    IEnumerable<T> Vehicles { get; }
    uint Count { get; }

    bool IsFull { get; }

    void ParkVehicle(T vehicle);
    void UnparkVehicle(T vehicle);
    bool IsParked(T vehicle);
}
