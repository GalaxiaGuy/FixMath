using GamesWithGravitas.FixMath;

namespace Tests;

public class BinaryNumberTests
{
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsPow2_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = F64.FromInt(input);
        var expected = int.IsPow2(input);
        
        var result = F64.IsPow2(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsPow2_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = F64.FromDouble(input);
        var expected = double.IsPow2(input);
        var result = F64.IsPow2(value);
        
        Assert.Equal(expected, result);
    }    
}