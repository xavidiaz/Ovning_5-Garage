namespace Ovning_5_Garage;

public static class Ui
{
    static Dictionary<string, string> menuOptions = new()
    {
        ["1"] = "Parkera",
        ["2"] = "Parkera av",
        ["3"] = "Parkerade fordon",
        ["4"] = "Parkerade fordon typer",
        ["5"] = "Seed Data",
        ["A"] = "Avsluta",
    };

    public static void List()
    {
        foreach (var option in menuOptions)
        {
            Console.WriteLine(option);
        }
    }

    public static void View()
    {
        GarageHandler _handler = new GarageHandler("P-central", 32);

        while (true)
        {
            List();
            Console.Write("Mata int din val:");
            string option = Console.ReadLine() ?? "";

            switch (option.ToUpper())
            {
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig val, försök igen!");
                    Console.ResetColor();
                    break;
                case "A":
                    Console.WriteLine("Hey då");
                    return;
                case "1":
                    Console.Clear();
                    string registreringsNumber = Helpers.Response("Ange registrerings nummer:");
                    // _handler.ParkVehicle(new);
                    Console.WriteLine(menuOptions["1"]);
                    break;
                case "5":
                    Console.Clear();
                    _handler.Seed();
                    Console.WriteLine("Seed data adderade!");
                    break;
            }
        }
    }
}
