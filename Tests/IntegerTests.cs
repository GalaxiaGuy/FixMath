using System.Numerics;
using System.Security.Cryptography;
using GamesWithGravitas.FixMath;

namespace Tests;

public class IntegerTests
{
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsInteger_WithInteger_ShouldReturnTrue(int input)
    {
        var value = F64.FromInt(input);
        
        var result = F64.IsInteger(value);
        
        Assert.True(result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = F64.FromDouble(input);
        var expected = double.IsInteger(input);
        var result = F64.IsInteger(value);
        
        Assert.Equal(expected, result);
    }
}
