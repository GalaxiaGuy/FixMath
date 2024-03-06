using GamesWithGravitas.FixMath;

namespace Tests;

public abstract class IsIntegerTests<T> where T : IFx<T>
{
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsInteger_WithInteger_ShouldReturnTrue(int input)
    {
        var value = T.FromInt(input);
        
        var result = T.IsInteger(value);
        
        Assert.True(result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = T.FromDouble(input);
        var expected = double.IsInteger(input);
        
        var result = T.IsInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsEvenInteger_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = T.FromInt(input);
        var expected = int.IsEvenInteger(input);
        
        var result = T.IsEvenInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsEvenInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = T.FromDouble(input);
        var expected = double.IsEvenInteger(input);
        var result = T.IsEvenInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(IntegerData.Singles), MemberType = typeof(IntegerData))]
    public void IsOddInteger_WithInteger_ShouldReturnCorrectValue(int input)
    {
        var value = T.FromInt(input);
        var expected = int.IsOddInteger(input);
        
        var result = T.IsOddInteger(value);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(DoubleData.Singles), MemberType = typeof(DoubleData))]
    public void IsOddInteger_WithDouble_ShouldReturnCorrectValue(double input)
    {
        var value = T.FromDouble(input);
        var expected = double.IsOddInteger(input);
        var result = T.IsOddInteger(value);
        
        Assert.Equal(expected, result);
    }
}

public class F32IsIntegerTests : IsIntegerTests<F32> { }
public class F64IsIntegerTests : IsIntegerTests<F64> { }