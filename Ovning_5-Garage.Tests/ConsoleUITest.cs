namespace Ovning_5_Garage.Tests;

public class ConsoleUITests
{
    [Fact]
    public void Run_OptionZero_ExitsLoopImmediately()
    {
        // Description: Verifies that selecting "0" in the main menu exits the loop cleanly
        // without crashing or looping infinitely.

        // Arrange
        var handler = new Handler();
        var ui = new ConsoleUI(handler);

        // Simulate typing "0" and pressing Enter
        using var input = new StringReader("0\n");
        using var output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        // Act
        ui.Run();

        // Assert
        string resultLines = output.ToString();
        Assert.Contains("--- GARAGE MENY ---", resultLines);
        Assert.Contains("Välj ett alternativ:", resultLines);
    }

    [Fact]
    public void CreateGarage_ValidInput_CallsHandlerAndPrintsSuccess()
    {
        // Description: Simulates selecting option '1', entering a garage name and a valid capacity,
        // then exiting. Verifies the UI prints a confirmation message.

        // Arrange
        var handler = new Handler();
        var ui = new ConsoleUI(handler);

        // Sequence of user inputs:
        // "1" (Select Create Garage)
        // "TestGarage" (Name)
        // "5" (Capacity)
        // "0" (Exit menu on the next loop)
        using var input = new StringReader("1\nTestGarage\n5\n0\n");
        using var output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        // Act
        ui.Run();

        // Assert
        string resultLines = output.ToString();
        Assert.Contains("Garage skapat!", resultLines);
    }

    [Fact]
    public void CreateGarage_InvalidCapacityInput_RetriesUntilValid()
    {
        // Description: Verifies the ReadInput<T> catch block works by feeding an invalid
        // capacity string ("abc"), checking for an error message, then feeding a valid integer.

        // Arrange
        var handler = new Handler();
        var ui = new ConsoleUI(handler);

        // Sequence of user inputs:
        // "1" (Select Create Garage)
        // "ErrorGarage" (Name)
        // "abc" (Invalid capacity -> triggers catch block)
        // "10" (Valid capacity on retry)
        // "0" (Exit menu)
        using var input = new StringReader("1\nErrorGarage\nabc\n10\n0\n");
        using var output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        // Act
        ui.Run();

        // Assert
        string resultLines = output.ToString();
        Assert.Contains("Ogiltig inmatning, försök igen.", resultLines);
        Assert.Contains("Garage skapat!", resultLines);
    }

    [Fact]
    public void ParkVehicle_CarInput_CollectsDataAndParksSuccessfully()
    {
        // Description: Ensures that when choosing to park a car, the interface steps through
        // all custom properties (doors, wheels) and parses them without throwing errors.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("UI Park Garage", 5); // Must have a garage created first
        var ui = new ConsoleUI(handler);

        // Sequence of inputs:
        // "2" (Select Park Vehicle)
        // "car" (Vehicle type)
        // "Volvo" (Brand)
        // "XYZ-987" (Reg ID)
        // "Black" (Color)
        // "4" (Wheels)
        // "5" (Doors)
        // "0" (Exit menu)
        using var input = new StringReader("2\ncar\nVolvo\nXYZ-987\nBlack\n4\n5\n0\n");
        using var output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        // Act
        ui.Run();

        // Assert
        (bool found, int _) = handler.FindVehicle("XYZ-987");
        Assert.True(found); // Confirms the car was successfully saved down to the handler layer
    }

    [Fact]
    public void SearchVehicles_ByColorOption_FiltersOutputList()
    {
        // Description: Tests that UI filter search option "1" requests a color
        // and safely executes the filter view output.

        // Arrange
        var handler = new Handler();
        handler.CreateGarage("SearchUI", 2);
        handler.ParkVehicle(new Car("Volvo", "AAA-111", "Red", 4, 5));
        var ui = new ConsoleUI(handler);

        // Sequence of inputs:
        // "7" (Select Search)
        // "1" (Filter by color option)
        // "Red" (Color search query)
        // "0" (Exit menu)
        using var input = new StringReader("7\n1\nRed\n0\n");
        using var output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        // Act
        ui.Run();

        // Assert
        string resultLines = output.ToString();
        Assert.Contains("AAA-111", resultLines); // Verify the targeted vehicle data printed to output stream
    }
}
