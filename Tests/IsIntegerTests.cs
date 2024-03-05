using GamesWithGravitas.FixMath;

namespace Tests;

public class IsIntegerTests
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
    
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsEvenInteger_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = F64.FromInt(input);
        var expected = int.IsEvenInteger(input);
        
        var result = F64.IsEvenInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsEvenInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = F64.FromDouble(input);
        var expected = double.IsEvenInteger(input);
        var result = F64.IsEvenInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsOddInteger_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = F64.FromInt(input);
        var expected = int.IsOddInteger(input);
        
        var result = F64.IsOddInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsOddInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = F64.FromDouble(input);
        var expected = double.IsOddInteger(input);
        var result = F64.IsOddInteger(value);
        
        Assert.Equal(expected, result);
    }
}