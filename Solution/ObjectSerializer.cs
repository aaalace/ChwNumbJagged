using Lib;
using LibNJ;

namespace Solution;

public static class ObjectSerializer
{
    private const string OSSeparatorStart = "{";
    private const string OSSeparatorClose = "}\n";

    public static void SerializeAndWrite(NumbJagged obj)
    {
        ConsoleInteraction.Write(obj.JArray.Length.ToString() + ' ', ConsoleColor.Green);
        ConsoleInteraction.Write(OSSeparatorStart, ConsoleColor.White, true);
        
        ConsoleInteraction.WriteLine("Object rows:", ConsoleColor.DarkYellow);
        ConsoleInteraction.WriteLine(obj.AsString());
        
        ConsoleInteraction.WriteLine("Possible triangles:", ConsoleColor.DarkYellow);
        for (int i = 0; i < obj.JArray.Length; i++)
        {
            ConsoleInteraction.Write($"{i + 1}) ");
            ConsoleInteraction.Write(obj.TriangleNumber(i).ToString(), ConsoleColor.White, true);
        }
        
        ConsoleInteraction.WriteLine(OSSeparatorClose);
    }

    public static void SerializeObjWithError(int errorInt)
    {
        ConsoleInteraction.Write(errorInt.ToString() + ' ', ConsoleColor.Green);
        ConsoleInteraction.Write(OSSeparatorStart, ConsoleColor.White, true);
        ConsoleInteraction.Write("Can not create object using value ", ConsoleColor.Red);
        ConsoleInteraction.Write(errorInt.ToString(), ConsoleColor.Red, true);
        ConsoleInteraction.WriteLine(OSSeparatorClose);
    }
}