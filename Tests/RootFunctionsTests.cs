using GamesWithGravitas.FixMath;

namespace Tests;

public class RootFunctionsTests
{
    [Theory]
    [MemberData(nameof(DoubleData.NonNegativeSingles), MemberType = typeof(DoubleData))]
    public void Cbrt_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.Cbrt(input);
        if (input > F64.MaxValue.Double || input < F64.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = F64.Cbrt(F64.FromDouble(input));
        
        Assert.Equal(expected, result.Double, 3);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void Hypot_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.Hypot(input, input);
        if (input > F64.MaxValue.Double || input < F64.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = F64.Hypot(F64.FromDouble(input), F64.FromDouble(input));
        
        Assert.Equal(expected, result.Double, 3);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.NonNegativeSingles), MemberType = typeof(DoubleData))]
    public void RootN_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var expected = double.RootN(input, 3);
        if (input > F64.MaxValue.Double || input < F64.MinValue.Double || double.IsNaN(input))
        {
            expected = 0;
        }
        
        var result = F64.RootN(F64.FromDouble(input), 3);
        
        Assert.Equal(expected, result.Double, 3);
    }
}