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

    public int TriangleNumber(int currentN)
    {
        if (currentN > jagArr.Length - 1 | currentN < 0) { throw new IndexOutOfRangeException(); }

        int[] row = jagArr[currentN];
        if (row.Length < 4) { return 0;}
        
        int count = 0;
        for (int i = 0; i < row.Length - 3; i++)
        {
            for (int j = 1; j < row.Length - 2; j++)
            {
                for (int k = 2; k < row.Length - 1; k++)
                {
                    int max = Math.Max(i, Math.Max(j, k));
                    if (max < i + j + k - max)
                    {
                        count += 1;
                    }
                }
            }
        }

        return count;
    }

    private static int[][] CompileJagArr(int n)
    {
        int[][] newArr = new int[n][];
        
        for (int i = 0; i < n; i++)
        {
            newArr[i] = CreateArrRow();
        }
        
        return newArr;
    }

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