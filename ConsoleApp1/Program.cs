// See https://aka.ms/new-console-template for more information
using System.Reflection;

var logs = new int[][]
{
    new int[] { 0, 5 },
    new int[] { 2, 2 },
    new int[] { 0, 2 },
    new int[] { 0, 5 },
    new int[] { 1, 3 },
    new int[] { 0, 1 },
    new int[] { 1, 1 }
};

//[[0,5],[2,2],[0,2],[0,5],[1,3],[0,1],[1,1]]

var result = FindMinMax(logs);
Console.WriteLine($"MinId: {result[0]}, MaxId: {result[1]}");
Console.ReadKey();

static int[] FindMinMax(int[][] logs)
{
    Dictionary<int, HashSet<int>> KPIs = new Dictionary<int, HashSet<int>>();
 
    //O(n)
    foreach (var log in logs)
    {
       int studentId = log[0];
       int minute = log[1];

        if(!KPIs.ContainsKey(studentId))
        {
            KPIs[studentId] = new HashSet<int>();
        }

        //O(1)
        KPIs[studentId].Add(minute);
    }


    int minId = int.MaxValue;
    int maxId = int.MinValue;

    int minVal = int.MaxValue;
    int maxVal = int.MinValue;
    //O(s)
    foreach (var kpi in KPIs)
    {
        int count = kpi.Value.Count;

        if (count < minVal)
        {
            minVal = count;
            minId = kpi.Key;
        }

        if (count > maxVal)
        {
            maxVal = count;
            maxId = kpi.Key;
        }
    }

    return new int[] { minId, maxId };
}