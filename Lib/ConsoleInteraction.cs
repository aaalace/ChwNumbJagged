namespace Lib;

public static class ConsoleInteraction
{
    public static void Write(string output, ConsoleColor color = ConsoleColor.White, bool toNextLine = false)
    {
        Console.ForegroundColor = color;
        Console.Write(output);
        if (toNextLine)
        {
            Console.Write('\n');
        }
        Console.ResetColor();
    }
    
    public static void WriteLine(string output, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(output);
        Console.ResetColor();
    }

    public static string? ReadLine()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("> ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string? input = Console.ReadLine();
        Console.ResetColor();
        return input;
    }
}