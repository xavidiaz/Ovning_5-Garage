namespace Ovning_5_Garage.Tests;

public class HandlerTests
{
    [Fact]
    public void CreateGarage_ValidInput_InitializesGarage()
    {
        // Description: Verifies that calling CreateGarage successfully initializes the internal garage,
        // allowing operations like ListVehicles to return an empty collection instead of crashing.

        // Arrange
        var handler = new Handler();

        // Act
        handler.CreateGarage("Main Street Garage", 10);
        var vehicles = handler.ListVehicles();

        // Assert
        Assert.Empty(vehicles); // Confirms garage exists and is empty, rather than null
    }

    [Fact]
    public void ParkVehicle_WithActiveGarage_AddsVehicleToGarage()
    {
        // Description: Verifies that ParkVehicle correctly routes the vehicle to the underlying garage instance.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("Test Garage", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);

        // Act
        handler.ParkVehicle(car);
        (bool found, int _) = handler.FindVehicle("ABC 123");

        // Assert
        Assert.True(found);
    }

    [Fact]
    public void UnparkVehicle_ExistingVehicle_RemovesVehicleFromGarage()
    {
        // Description: Verifies that UnparkVehicle routes the unpark command downward,
        // causing the vehicle to no longer be found.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("Test Garage", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);
        handler.ParkVehicle(car);

        // Act
        handler.UnparkVehicle("ABC 123");
        (bool found, int _) = handler.FindVehicle("ABC 123");

        // Assert
        Assert.False(found);
    }

    [Fact]
    public void ListVehicles_GarageNotCreated_ReturnsEmptyEnumerableSafely()
    {
        // Description: Guard rail test ensuring that if a user tries to list vehicles
        // before running CreateGarage, the system handles it gracefully without a NullReferenceException.

        // Arrange
        var handler = new Handler(); // _garage is implicitly null

        // Act
        var result = handler.ListVehicles();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void SearchVehicles_ValidFilter_ReturnsFilteredResults()
    {
        // Description: Tests that SearchVehicles passes down the lambda filter expressions
        // to retrieve targeted subsets from the garage.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("Search Garage", 5);

        var redCar = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var blueCar = new Car("Toyota", "DEF 456", "Blue", 4, 4);

        handler.ParkVehicle(redCar);
        handler.ParkVehicle(blueCar);

        // Act
        var results = handler.SearchVehicles(v => v.Color == "Red").ToList();

        // Assert
        Assert.Single(results);
        Assert.Equal("ABC 123", results[0].Id);
    }

    [Fact]
    public void ListVehicleTypes_WithVehicles_GroupsThemCorrectly()
    {
        // Description: Tests that the type-grouping logic inside the garage works seamlessly
        // when called via the handler endpoint.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("Grouping Garage", 5);

        var car1 = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var car2 = new Car("Toyota", "DEF 456", "Blue", 4, 4);
        var bike = new Motorcycle("Yamaha", "GHI 789", "Black", 2, 85);

        handler.ParkVehicle(car1);
        handler.ParkVehicle(car2);
        handler.ParkVehicle(bike);

        // Act
        var groupings = handler.ListVehicleTypes().ToList();

        // Assert
        // Expecting 2 distinct groups: "Car" and "Motorcycle"
        Assert.Equal(2, groupings.Count);

        var carGroup = groupings.FirstOrDefault(g => g.Key == "Car");
        var bikeGroup = groupings.FirstOrDefault(g => g.Key == "Motorcycle");

        Assert.NotNull(carGroup);
        Assert.Equal(2, carGroup.Count()); // 2 cars

        Assert.NotNull(bikeGroup);
        Assert.Single(bikeGroup); // 1 motorcycle
    }

    [Fact]
    public void SeedGarage_WhenCalled_PopulatesGarageWithInitialData()
    {
        // Description: Tests that SeedGarage feeds preset vehicle units into the active garage collection.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("Seed Garage", 10);

        // Act
        handler.SeedGarage();
        var totalVehicles = handler.ListVehicles().Count();

        // Assert
        // Seed method inside Garage.cs adds exactly 4 items (2 Cars, 2 Motorcycles)
        Assert.Equal(4, totalVehicles);
    }
}
