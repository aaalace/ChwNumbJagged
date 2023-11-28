namespace Lib;

public static class Utils
{
    /// <summary>
    /// Converts data from file (array of strings) to array of integers if data is correct.
    /// </summary>
    /// <param name="arr">Array of strings.</param>
    /// <returns>Array of integers.</returns>
    /// <exception cref="FormatException">If any element can not be converted to integer.</exception>
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

    /// <summary>
    /// Gets path, checks it on null, creates file, saves data there if it's possible.
    /// </summary>
    /// <param name="sList">List of data expected to be written to file.</param>
    /// <returns>State of saving.</returns>
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