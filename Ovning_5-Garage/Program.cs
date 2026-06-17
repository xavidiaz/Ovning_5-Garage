namespace Ovning_5_Garage;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Initialize the central handler/orchestrator
        Handler handler = new Handler();

        // 2. Pass the handler into the ConsoleUI constructor
        ConsoleUI ui = new ConsoleUI(handler);

        // 3. Start the main user interface loop
        ui.Run();
    }
}
