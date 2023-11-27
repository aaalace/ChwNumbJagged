namespace Lib;

public static class Utils
{
    public static int[] ConvertStringArrToIntArr(string?[] arr)
    {
        int[] nArr = new int[arr.Length];
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (!int.TryParse(arr[i], out int n)) { throw new FormatException(); }
            nArr[i] = n;
        }

        return nArr;
    }

    public static bool SaveFile(List<string> sList)
    {
        ConsoleInteraction.WriteLine(ConstantMessages.TypeNewPath);
        string? filePath = ConsoleInteraction.ReadLine();
        if (filePath == null) { return false; }
        try
        {
            using StreamWriter file = new(filePath, append: true);
            foreach (string s in sList)
            {
                file.WriteLine(s);
            }
            file.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}