using GamesWithGravitas.FixMath;

namespace Tests;

public abstract class BinaryNumberTests<T> where T : IFx<T>
{
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsPow2_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = T.FromInt(input);
        var expected = int.IsPow2(input);
        
        var result = T.IsPow2(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsPow2_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = T.FromDouble(input);
        var expected = double.IsPow2(input);
        var result = T.IsPow2(value);
        
        Assert.Equal(expected, result);
    }    
}

public class F32BinaryNumberTests : BinaryNumberTests<F32> { }
public class F64BinaryNumberTests : BinaryNumberTests<F64> { }
