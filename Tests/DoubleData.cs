namespace Tests;

public static class DoubleData
{
    private static IEnumerable<double> Raw()
    {
        yield return 0;
        for (int i = 1; i < 10; i++)
        {
            yield return i;
            yield return -1;
            yield return 100.5 * i;
        }

        yield return double.E;
        yield return double.Pi;
    }
    public static IEnumerable<object[]> Singles()
    {
        foreach (var x in Raw())
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