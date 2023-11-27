using Lib;

namespace Solution;

public static class Program
{
    // Correct file format:
    // N1 <integer: size of first NumbJaggedArray>
    // N2 <integer: size of second NumbJaggedArray>
    // ...
    
    public static void Main()
    {
        bool cycleState;
        do
        {
            cycleState = LoopBodyContainer.LoopBody();
            if (cycleState) { ConsoleInteraction.PressKeyOption(); }
        } while (!cycleState || Console.ReadKey(true).Key != ConsoleKey.Q);
    }
}