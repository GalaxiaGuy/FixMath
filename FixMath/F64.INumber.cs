using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GamesWithGravitas.FixMath;

public partial struct F64 : INumber<F64>
{
    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        return Double.ToString(format, formatProvider);
    }

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return Double.TryFormat(destination, out charsWritten, format, provider);
    }

    static F64 IParsable<F64>.Parse(string s, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, provider));
    }

    static bool IParsable<F64>.TryParse(string? s, IFormatProvider? provider, out F64 result)
    {
        var success = double.TryParse(s, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static F64 ISpanParsable<F64>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, provider));
    }

    static bool ISpanParsable<F64>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out F64 result)
    {
        var success = double.TryParse(s, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static F64 IAdditiveIdentity<F64, F64>.AdditiveIdentity => Zero;
    
    static F64 IMultiplicativeIdentity<F64, F64>.MultiplicativeIdentity => One;
    
    static F64 IUnaryPlusOperators<F64, F64>.operator +(F64 value) => value;

    static bool INumberBase<F64>.IsCanonical(F64 value) => true;

    static bool INumberBase<F64>.IsComplexNumber(F64 value) => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEvenInteger(F64 value)
    {
        return (value.Raw & 0x0000_0001_FFFF_FFFF) == 0;
    }

    static bool INumberBase<F64>.IsFinite(F64 value) => true;

    static bool INumberBase<F64>.IsImaginaryNumber(F64 value) => false;

    static bool INumberBase<F64>.IsInfinity(F64 value) => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInteger(F64 value)
    {
        return (value.Raw & 0x0000_0000_FFFF_FFFF) == 0;
    }

    static bool INumberBase<F64>.IsNaN(F64 value) => false;

    static bool INumberBase<F64>.IsNegative(F64 value) => value.Raw < 0;

    static bool INumberBase<F64>.IsNegativeInfinity(F64 value) => false;

    static bool INumberBase<F64>.IsNormal(F64 value) => true;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOddInteger(F64 value)
    {
        return (value.Raw & 0x0000_0001_FFFF_FFFF) == 0x0000_0001_0000_0000;
    }

    static bool INumberBase<F64>.IsPositive(F64 value) => value.Raw > 0;

    static bool INumberBase<F64>.IsPositiveInfinity(F64 value) => false;

    static bool INumberBase<F64>.IsRealNumber(F64 value) => true;

    static bool INumberBase<F64>.IsSubnormal(F64 value) => false;

    static bool INumberBase<F64>.IsZero(F64 value) => value.Raw == 0;

    static F64 INumberBase<F64>.MaxMagnitude(F64 x, F64 y) => Max(Abs(x), Abs(y));

    static F64 INumberBase<F64>.MaxMagnitudeNumber(F64 x, F64 y) => Max(Abs(x), Abs(y));

    static F64 INumberBase<F64>.MinMagnitude(F64 x, F64 y) => Min(Abs(x), Abs(y));

    static F64 INumberBase<F64>.MinMagnitudeNumber(F64 x, F64 y) => Min(Abs(x), Abs(y));

    static F64 INumberBase<F64>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, style, provider));
    }

    static F64 INumberBase<F64>.Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, style, provider));
    }

    private static bool TryConvertFrom<TOther>(TOther value, out F64 result)
    {
        if (typeof(TOther) == typeof(double))
        {
            result = FromDouble((double)(object)value!);
            return true;
        }
        else if (typeof(TOther) == typeof(float))
        {
            result = FromFloat((float)(object)value!);
            return true;
        }
        else if (typeof(TOther) == typeof(int))
        {
            result = FromInt((int)(object)value!);
            return true;
        }
        else if (typeof(TOther) == typeof(F32))
        {
            result = FromF32((F32)(object)value!);
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }
    
    private static bool TryConvertTo<TOther>(F64 value, [MaybeNullWhen(false)] out TOther result)
    {
        if (typeof(TOther) == typeof(double))
        {
            result = (TOther)(object)value.Double;
            return true;
        }
        else if (typeof(TOther) == typeof(float))
        {
            result = (TOther)(object)value.Float;
            return true;
        }
        else if (typeof(TOther) == typeof(int))
        {
            result = (TOther)(object)(int)value.Double;
            return true;
        }
        else if (typeof(TOther) == typeof(F32))
        {
            result = (TOther)(object)value.F32;
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }

    static bool INumberBase<F64>.TryConvertFromChecked<TOther>(TOther value, out F64 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F64>.TryConvertFromSaturating<TOther>(TOther value, out F64 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F64>.TryConvertFromTruncating<TOther>(TOther value, out F64 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F64>.TryConvertToChecked<TOther>(F64 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F64>.TryConvertToSaturating<TOther>(F64 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F64>.TryConvertToTruncating<TOther>(F64 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F64>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out F64 result)
    {
        var success = double.TryParse(s, style, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static bool INumberBase<F64>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out F64 result)
    {
        var success = double.TryParse(s, style, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static int INumberBase<F64>.Radix => 2;
}
