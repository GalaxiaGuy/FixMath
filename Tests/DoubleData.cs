namespace Tests;

public static class DoubleData
{
    private static IEnumerable<double> Raw()
    {
        yield return 0;
        for (var i = 1; i < 4; i++)
        {
            yield return i;
            yield return -i;
            yield return 10 * i;
            yield return 10.5 * i;
        }

        yield return double.E;
        yield return double.Pi;
        yield return double.Tau;
    }
    public static IEnumerable<object[]> Singles()
    {
        foreach (var x in Raw())
        {
            yield return [x];
        }
    }
    
    public static IEnumerable<object[]> NonNegativeSingles()
    {
        foreach (var x in Raw().Where(x => x >= 0))
        {
            yield return [x];
        }
    }
    public static IEnumerable<object[]> Pairs()
    {
        foreach (var x in Raw())
        {
            foreach (var y in Raw())
            {
                yield return [x, y];
            }
        }
    }
}