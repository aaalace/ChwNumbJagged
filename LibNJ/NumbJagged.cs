using System.Text;

namespace LibNJ;

public class NumbJagged
{
    private int[][] jagArr;

    public int[][] JArray => jagArr;

    public NumbJagged()
    {
        jagArr = Array.Empty<int[]>();
    }
    
    public NumbJagged(int n)
    {
        jagArr = n >= 0 ? CompileJagArr(n) : Array.Empty<int[]>();
    }

    /// <summary>
    /// Refactor object's data in arrays to general string.
    /// </summary>
    /// <returns>Represented object elements as string.</returns>
    public string AsString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < jagArr.Length; i++)
        {
            sb.Append("| ");
            for (int j = 0; j < jagArr[i].Length; j++)
            {
                sb.Append(jagArr[i][j]);
                if (j != jagArr[i].Length - 1) { sb.Append(" | "); }
            }
            sb.Append(" |");
            if (i != jagArr.Length - 1) { sb.Append('\n'); }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Counts how much triangles can be made based on numbers in given row.
    /// </summary>
    /// <param name="currentN">Serial number of row to choose.</param>
    /// <returns>Number of possible triangles.</returns>
    /// <exception cref="IndexOutOfRangeException">Throws if currentN is not in range of object's rows.</exception>
    public int TriangleNumber(int currentN)
    {
        if (currentN > jagArr.Length - 1 | currentN < 0) { throw new IndexOutOfRangeException(); }

        int[] row = jagArr[currentN];
        if (row.Length < 4) { return 0;}
        
        int[] toWorkWith = removeDuplicates(row);
        
        int count = 0;
        for (int i = 0; i < toWorkWith.Length - 3; i++)
        {
            for (int j = 1; j < toWorkWith.Length - 2; j++)
            {
                for (int k = 2; k < toWorkWith.Length - 1; k++)
                {
                    if (toWorkWith[i] + toWorkWith[j] > toWorkWith[k] &&
                        toWorkWith[i] + toWorkWith[k] > toWorkWith[j] &&
                        toWorkWith[j] + toWorkWith[k] > toWorkWith[i])
                    {
                        count++;
                    }
                }
            }
        }

        return count;

        static int[] removeDuplicates(int[] array)
        {
            var set = new HashSet<int>(array);
            int[] result = new int[set.Count];
            set.CopyTo(result);
            return result;
        }
    }

    /// <summary>
    /// Creates major array of object's elements.
    /// </summary>
    /// <param name="n">Number of elements in major array.</param>
    /// <returns>Major array.</returns>
    private static int[][] CompileJagArr(int n)
    {
        int[][] newArr = new int[n][];
        
        for (int i = 0; i < n; i++)
        {
            newArr[i] = CreateArrRow();
        }
        
        return newArr;
    }

    /// <summary>
    /// Creates row of major array.
    /// </summary>
    /// <returns>Current row of major array.</returns>
    private static int[] CreateArrRow()
    {
        var rowList = new List<int>(); 
        var rnd = new Random();
        
        while (true)
        {
            int elem = rnd.Next(0, 6);
            rowList.Add(elem);
            if (elem == 0) { break; }
        }

        int[] resArr = new int[rowList.Count];
        for (int i = 0; i < rowList.Count; i++)
        {
            resArr[i] = rowList[i];
        }

        return resArr;
    }
}