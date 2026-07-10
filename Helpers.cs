namespace Ovning_5_Garage;

public static class Helpers
{
    public static string Response(string answer)
    {
        string result = "";
        while (true)
        {
            Console.WriteLine(answer);
            result = Console.ReadLine() ?? "";
            if (result is not "")
                return result;
            else
                Console.WriteLine("försök igen!");
        }
    }
}
