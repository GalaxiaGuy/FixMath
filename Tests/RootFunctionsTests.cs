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
        
        Assert.Equal(expected, result.Double, 1);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Pairs), MemberType = typeof(DoubleData))]
    public void Hypot_WithDouble_ShouldReturnCorrectValue(double inputX, double inputY)
    {
        var expected = double.Hypot(inputX, inputY);
        if (inputX > T.MaxValue.Double || inputX < T.MinValue.Double || double.IsNaN(inputX) ||
            inputY > T.MaxValue.Double || inputY < T.MinValue.Double || double.IsNaN(inputY))
        {
            expected = 0;
        }
        
        var result = T.Hypot(T.FromDouble(inputX), T.FromDouble(inputY));
        
        Assert.Equal(expected, result.Double, 1);
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
        
        Assert.Equal(expected, result.Double, 1);
    }
}

public class F32RootFunctionsTests : RootFunctionsTests<F32> { }
public class F64RootFunctionsTests : RootFunctionsTests<F64> { }