namespace Ovning_5_Garage.Tests;

public class GarageTests
{
    [Fact]
    public void VehicleCount_NewGarage_ReturnsZero()
    {
        // Description: Verifies that a freshly created garage starts with an initial count of 0.

        // Arrange & Act
        var garage = new Garage<IVehicle>("Initial Test", 3);

        // Assert
        Assert.Equal((uint)0, garage.VehicleCount);
    }

    [Fact]
    public void ParkVehicle_EmptyGarage_VehicleIsParked()
    {
        // Description: Verifies that when a vehicle is successfully parked,
        // the garage can successfully look it up by its ID.

        // Arrange
        var garage = new Garage<IVehicle>("Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);

        // Act
        garage.ParkVehicle(car);
        (bool found, int _) = garage.FindVehicle("ABC 123");

        // Assert
        Assert.True(found);
    }

    [Fact]
    public void ParkVehicle_OneVehicle_CountIsOne()
    {
        // Description: Verifies that parking a single vehicle increments the total count to exactly 1.

        // Arrange
        var garage = new Garage<IVehicle>("Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);

        // Act
        garage.ParkVehicle(car);

        // Assert
        Assert.Equal((uint)1, garage.VehicleCount);
    }

    [Fact]
    public void ParkVehicle_MultipleVehicles_CountTracksCorrectly()
    {
        // Description: Verifies that the internal vehicle counter tracks multiple
        // separate parking additions sequentially.

        // Arrange
        var garage = new Garage<IVehicle>("Multi Test", 10);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var bike = new Motorcycle("Yamaha", "GHI 789", "Black", 2, 85);

        // Act
        garage.ParkVehicle(car);
        garage.ParkVehicle(bike);

        // Assert
        Assert.Equal((uint)2, garage.VehicleCount);
    }

    [Fact]
    public void UnparkVehicle_VehicleExists_DecrementsCount()
    {
        // Description: Verifies that removing an existing vehicle successfully decrements
        // the total vehicle count. (Note: This will fail until fixed in Garage.cs!)

        // Arrange
        var garage = new Garage<IVehicle>("Unpark Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);
        garage.ParkVehicle(car); // Count is 1

        // Act
        garage.UnparkVehicle("ABC 123");

        // Assert
        Assert.Equal((uint)0, garage.VehicleCount);
    }

    [Fact]
    public void UnparkVehicle_VehicleDoesNotExist_CountRemainsUnchanged()
    {
        // Description: Verifies that attempting to unpark a registration ID that isn't present
        // leaves the vehicle count safely unchanged.

        // Arrange
        var garage = new Garage<IVehicle>("Ghost Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);
        garage.ParkVehicle(car); // Count is 1

        // Act
        garage.UnparkVehicle("XYZ 999"); // ID does not exist

        // Assert
        Assert.Equal((uint)1, garage.VehicleCount);
    }

    [Fact]
    public void ParkVehicle_GarageIsFull_CountDoesNotExceedCapacity()
    {
        // Description: Verifies that when the garage hits maximum capacity, subsequent attempts
        // to park a vehicle are rejected, and the counter stays capped at maximum capacity.

        // Arrange
        uint capacity = 2;
        var garage = new Garage<IVehicle>("Full Test", capacity);
        var car1 = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var car2 = new Car("Toyota", "DEF 456", "Blue", 4, 4);
        var car3 = new Car("Honda", "GHI 789", "Black", 4, 4);

        // Act
        garage.ParkVehicle(car1);
        garage.ParkVehicle(car2);
        garage.ParkVehicle(car3); // Should hit IsFull validation and stop execution

        // Assert
        Assert.Equal(capacity, garage.VehicleCount);
    }

    [Fact]
    public void FirstEmptySpace_WhenMiddleSlotBecomesEmpty_FillsFirstAvailableSlot()
    {
        // Description: Verifies that FirstEmptySpace correctly finds and fills the lowest
        // available index when a vehicle in the middle of the garage unparks.

        // Arrange
        var garage = new Garage<IVehicle>("Empty Space Test", 3);
        var car1 = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var car2 = new Car("Toyota", "DEF 456", "Blue", 4, 4);
        var car3 = new Car("Honda", "GHI 789", "Black", 4, 4);

        garage.ParkVehicle(car1); // Goes to index 0
        garage.ParkVehicle(car2); // Goes to index 1
        garage.ParkVehicle(car3); // Goes to index 2

        // Act
        garage.UnparkVehicle("DEF 456"); // Frees up index 1

        var newCar = new Car("Ford", "XYZ 789", "White", 4, 4);
        garage.ParkVehicle(newCar); // FirstEmptySpace should pick index 1

        (_, int foundIndex) = garage.FindVehicle("XYZ 789");

        // Assert
        Assert.Equal(1, foundIndex); // Confirms index 1 was recycled!
    }

    [Fact]
    public void FindVehicle_WhenVehicleExists_ReturnsTrueAndCorrectIndex()
    {
        // Description: Verifies FindVehicle returns true and the exact array index
        // when a matching registration ID is found.

        // Arrange
        var garage = new Garage<IVehicle>("Find Test", 5);
        var car = new Car("Toyota", "DEF 456", "Blue", 4, 4);
        garage.ParkVehicle(car);

        // Act
        (bool found, int index) = garage.FindVehicle("DEF 456");

        // Assert
        Assert.True(found);
        Assert.Equal(0, index);
    }

    [Fact]
    public void FindVehicle_WhenVehicleDoesNotExist_ReturnsFalse()
    {
        // Description: Verifies FindVehicle returns false when searching for an ID not in the garage.

        // Arrange
        var garage = new Garage<IVehicle>("Find Test", 5);

        // Act
        (bool found, int _) = garage.FindVehicle("NONEXISTENT");

        // Assert
        Assert.False(found);
    }

    [Fact]
    public void FindVehicle_IsCaseInsensitive_ReturnsTrue()
    {
        // Description: Verifies that FindVehicle matches IDs regardless of casing (e.g., "abc 123" matches "ABC 123").

        // Arrange
        var garage = new Garage<IVehicle>("Find Case Test", 5);
        var car = new Car("Volvo", "ABC 123", "Red", 4, 5);
        garage.ParkVehicle(car);

        // Act
        (bool found, int _) = garage.FindVehicle("abc 123"); // Lowercase query

        // Assert
        Assert.True(found);
    }

    [Fact]
    public void SearchVehicles_WithColorFilter_ReturnsOnlyMatchingVehicles()
    {
        // Description: Verifies SearchVehicles accurately filters and returns a collection
        // of vehicles matching a specific lambda expression condition (e.g., Color == "Red").

        // Arrange
        var garage = new Garage<IVehicle>("Search Test", 5);
        var redCar = new Car("Volvo", "ABC 123", "Red", 4, 5);
        var blueCar = new Car("Toyota", "DEF 456", "Blue", 4, 4);

        garage.ParkVehicle(redCar);
        garage.ParkVehicle(blueCar);

        // Act
        var searchResult = garage.SearchVehicles(v => v.Color == "Red").ToList();

        // Assert
        Assert.Single(searchResult); // Should find exactly 1 vehicle
        Assert.Contains(redCar, searchResult);
        Assert.DoesNotContain(blueCar, searchResult);
    }
}
