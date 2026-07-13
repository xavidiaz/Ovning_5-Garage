namespace Ovning_5_Garage;

public static class Helpers
{
    public static T Response<T>(string prompt, TryParseHandler<T> tryParse)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";

            if (tryParse(input, out T result))
                return result;

            Console.WriteLine("Försök igen!");
        }
    }

    // Delegate-typen — beskriver formen på en TryParse-metod
    public delegate bool TryParseHandler<T>(string input, out T result);

    public static bool StringTryParse(string input, out string result)
    {
        result = input;
        return !string.IsNullOrWhiteSpace(input);
    }
}
