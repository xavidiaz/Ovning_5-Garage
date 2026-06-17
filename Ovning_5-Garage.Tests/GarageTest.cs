using Ovning_5_Garage;

namespace Ovning_5_Garage.Tests;

public class GarageTests
{
    [Fact]
    public void ParkVehicle_EmptyGarage_VehicleIsParked()
    {
        // Arrange
        var garage = new Garage<Vehicle>("Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);

        // Act
        garage.ParkVehicle(car);

        // Assert
        (bool found, int _) = garage.FindVehicle("ABC 123");
        Assert.True(found);
    }
}
