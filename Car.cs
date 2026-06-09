
namespace Ovning_5_Garage
{
  public class Car : Vehicle
  {
    public FuelType FuelType { get; }

    public Car(string brand, string idNumber, FuelType fueltype) : base(brand, idNumber)
    {
      FuelType = fueltype;

    }
  }
}


