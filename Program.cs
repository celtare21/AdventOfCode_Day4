using System.Reflection;

var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
var lines = File.ReadAllLines($@"{filePath!}\1.txt").ToArray();

Console.WriteLine(GetFirstPartResult(lines));
Console.WriteLine(GetSecondPartResult(lines));

static (int min, int max) GetMinMax(string part)
{
    var range = part.Split('-');

    return (int.Parse(range[0]), int.Parse(range[1]));
}

static int GetFirstPartResult(IEnumerable<string> strings)
{
    var total = 0;

    foreach (var lineParts in strings.Select(line => line.Split(',')))
    {
        var (min1, max1) = GetMinMax(lineParts[0]);
        var (min2, max2) = GetMinMax(lineParts[1]);

        if (min1 >= min2 && max1 <= max2 || min2 >= min1 && max2 <= max1)
            ++total;
    }

    return total;
}

static int GetSecondPartResult(IEnumerable<string> strings)
{
    var total = 0;

    foreach (var lineParts in strings.Select(line => line.Split(',')))
    {
        var (min1, max1) = GetMinMax(lineParts[0]);
        var (min2, max2) = GetMinMax(lineParts[1]);

        if (max1 >= min2 && min1 <= max2)
            ++total;
    }

    return total;
}