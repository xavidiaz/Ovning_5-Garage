
namespace Ovning_5_Garage
{

  public class Garage : IGarage
  {
    public string Name { get; }
    public int Capacity { get; }

    public Garage(string name, int capacity)
    {
      Name = name;
      Capacity = capacity;
    }
  }
}


