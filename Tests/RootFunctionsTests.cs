using GamesWithGravitas.FixMath;

namespace Tests;

public abstract class RootFunctionsTests<T> where T : IFx<T>
{
    [Theory]
    [MemberData(nameof(DoubleData.NonNegativeSingles), MemberType = typeof(DoubleData))]
    public void Cbrt_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.Cbrt(input);
        if (input > T.MaxValue.Double || input < T.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = T.Cbrt(T.FromDouble(input));
        
        Assert.Equal(expected, result.Double, 3);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void Hypot_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.Hypot(input, input);
        if (input > T.MaxValue.Double || input < T.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = T.Hypot(T.FromDouble(input), T.FromDouble(input));
        
        Assert.Equal(expected, result.Double, 3);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.NonNegativeSingles), MemberType = typeof(DoubleData))]
    public void RootN_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.RootN(input, 3);
        if (input > T.MaxValue.Double || input < T.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = T.RootN(T.FromDouble(input), 3);
        
        Assert.Equal(expected, result.Double, 3);
    }
}

public class F64RootFunctionsTests : RootFunctionsTests<F64> { }