using GameInterfaces;

namespace GameBehaviour;

public class ConsoleInputProvider : IInputProvider
{
    private bool _fallbackMode = false;

    public ConsoleKey GetKey()
    {
        if (_fallbackMode)
        {
            return ReadLineFallback();
        }

        try
        {
            return Console.ReadKey(intercept: true).Key;
        }
        catch (InvalidOperationException)
        {
            _fallbackMode = true;
            Console.WriteLine("\n[WARNING] Standard console input not available (likely due to debugger). Switched to compatible mode.");
            Console.WriteLine("Please type your key and press ENTER to move (e.g., 'UpArrow' or just 'w' for simple games if supported).");
            return ReadLineFallback();
        }
    }

    private ConsoleKey ReadLineFallback()
    {
        Console.Write(">>> ");
        var input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            // Avoid infinite loop if console is detached or EOF
            if (input == null)
            {
                Console.WriteLine("[ERROR] Console input stream closed. Exiting game loop.");
                throw new InvalidOperationException("Console input not available.");
            }
            return ConsoleKey.NoName;
        }

        // Try to parse as Console Key (e.g. "Enter", "UpArrow")
        if (Enum.TryParse<ConsoleKey>(input, true, out var key))
        {
            return key;
        }

        // Handle single characters (w, a, s, d) if the game logic uses them? 
        // The current game logic (Navigator.cs) likely checks strictly for ArrowKeys.
        // Let's assume the user has` to type the key name for now, or we can map basics.
        // For Minefield, arrow keys are usually expected.
        return ConsoleKey.NoName;
    }
}
