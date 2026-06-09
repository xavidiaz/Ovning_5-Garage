namespace Ovning_5_Garage
{
  public class Motorcycle : Vehicle
  {
    public CylinderVolume CylinderVoulume { get; }
    public Motorcycle(string brand, string idNumber, CylinderVolume cylinderVolume) : base(brand, idNumber)
    {
      CylinderVoulume = cylinderVolume;
    }
  }
}

