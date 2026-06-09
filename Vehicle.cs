namespace Ovning_5_Garage
{

  public abstract class Vehicle : IVehicle
  {
    protected Vehicle(string brand, string idNumber)
    {
      Brand = brand;
      IdNumber = idNumber;
    }

    public string Brand { get; }
    public string IdNumber { get; }

  }
}


