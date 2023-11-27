using Lib;
using LibNJ;

namespace Solution;

public static class LoopBodyContainer
{
    public static bool LoopBody()
    {
        try
        {
            ConsoleInteraction.WriteLine(ConstantMessages.TypePath);
            string? filePath = ConsoleInteraction.ReadLine();
            if (filePath == null)
            {
                ConsoleInteraction.WriteLine(ConstantMessages.PathNull, ConsoleColor.Red);
                return false;
            }

            string?[] nStringArr = File.ReadAllLines(filePath);
            int[] nArr = Utils.ConvertStringArrToIntArr(nStringArr);
            var numbJaggedAsStrings = new List<string>();
            
            foreach (int n in nArr)
            {
                if (n < 0)
                {
                    ObjectSerializer.SerializeObjWithError(n);
                    continue;
                }

                var numbJaggedObject = new NumbJagged(n);
                ObjectSerializer.SerializeAndWrite(numbJaggedObject);
                numbJaggedAsStrings.Add(numbJaggedObject.AsString());
            }

            bool saveState = Utils.SaveFile(numbJaggedAsStrings);
            if (!saveState)
            {
                ConsoleInteraction.WriteLine(ConstantMessages.ErrorInSaving, ConsoleColor.Red);
            }
        }
        catch (FormatException)
        {
            ConsoleInteraction.WriteLine(ConstantMessages.FileWrongFormat, ConsoleColor.Red);
            return false;
        }
        catch (ArgumentException)
        {
            ConsoleInteraction.WriteLine(ConstantMessages.WrongPath, ConsoleColor.Red);
            return false;
        }
        catch (FileNotFoundException)
        {
            ConsoleInteraction.WriteLine(ConstantMessages.FileNF, ConsoleColor.Red);
            return false;
        }
        catch (IndexOutOfRangeException)
        {
            ConsoleInteraction.WriteLine(ConstantMessages.RowDontExists, ConsoleColor.Red);
            return false;
        }
        catch (Exception)
        {
            ConsoleInteraction.WriteLine(ConstantMessages.UnexpectedError, ConsoleColor.Red);
            return false;
        }

        return true;
    }
}