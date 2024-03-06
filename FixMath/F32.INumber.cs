using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GamesWithGravitas.FixMath;

public partial struct F32 : INumber<F32>
{
    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        return Double.ToString(format, formatProvider);
    }

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return Double.TryFormat(destination, out charsWritten, format, provider);
    }

    static F32 IParsable<F32>.Parse(string s, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, provider));
    }

    static bool IParsable<F32>.TryParse(string? s, IFormatProvider? provider, out F32 result)
    {
        var success = double.TryParse(s, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static F32 ISpanParsable<F32>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, provider));
    }

    static bool ISpanParsable<F32>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out F32 result)
    {
        var success = double.TryParse(s, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static F32 IAdditiveIdentity<F32, F32>.AdditiveIdentity => Zero;
    
    static F32 IMultiplicativeIdentity<F32, F32>.MultiplicativeIdentity => One;
    
    static F32 IUnaryPlusOperators<F32, F32>.operator +(F32 value) => value;

    static bool INumberBase<F32>.IsCanonical(F32 value) => true;

    static bool INumberBase<F32>.IsComplexNumber(F32 value) => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEvenInteger(F32 value)
    {
        return (value.Raw & 0x0001_FFFF) == 0;
    }

    static bool INumberBase<F32>.IsFinite(F32 value) => true;

    static bool INumberBase<F32>.IsImaginaryNumber(F32 value) => false;

    static bool INumberBase<F32>.IsInfinity(F32 value) => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInteger(F32 value)
    {
        return (value.Raw & 0x0000_FFFF) == 0;
    }

    static bool INumberBase<F32>.IsNaN(F32 value) => false;

    static bool INumberBase<F32>.IsNegative(F32 value) => value.Raw < 0;

    static bool INumberBase<F32>.IsNegativeInfinity(F32 value) => false;

    static bool INumberBase<F32>.IsNormal(F32 value) => true;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOddInteger(F32 value)
    {
        return (value.Raw & 0x0001_FFFF) == 0x0001_0000;
    }

    static bool INumberBase<F32>.IsPositive(F32 value) => value.Raw > 0;

    static bool INumberBase<F32>.IsPositiveInfinity(F32 value) => false;

    static bool INumberBase<F32>.IsRealNumber(F32 value) => true;

    static bool INumberBase<F32>.IsSubnormal(F32 value) => false;

    static bool INumberBase<F32>.IsZero(F32 value) => value.Raw == 0;

    static F32 INumberBase<F32>.MaxMagnitude(F32 x, F32 y) => Max(Abs(x), Abs(y));

    static F32 INumberBase<F32>.MaxMagnitudeNumber(F32 x, F32 y) => Max(Abs(x), Abs(y));

    static F32 INumberBase<F32>.MinMagnitude(F32 x, F32 y) => Min(Abs(x), Abs(y));

    static F32 INumberBase<F32>.MinMagnitudeNumber(F32 x, F32 y) => Min(Abs(x), Abs(y));

    static F32 INumberBase<F32>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, style, provider));
    }

    static F32 INumberBase<F32>.Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        return FromDouble(double.Parse(s, style, provider));
    }

    private static bool TryConvertFrom<TOther>(TOther value, out F32 result)
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
        else if (typeof(TOther) == typeof(F64))
        {
            result = FromF64((F64)(object)value!);
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }
    
    private static bool TryConvertTo<TOther>(F32 value, [MaybeNullWhen(false)] out TOther result)
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
        else
        {
            result = default;
            return false;
        }
    }

    static bool INumberBase<F32>.TryConvertFromChecked<TOther>(TOther value, out F32 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F32>.TryConvertFromSaturating<TOther>(TOther value, out F32 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F32>.TryConvertFromTruncating<TOther>(TOther value, out F32 result)
    {
        return TryConvertFrom(value, out result);
    }

    static bool INumberBase<F32>.TryConvertToChecked<TOther>(F32 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F32>.TryConvertToSaturating<TOther>(F32 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F32>.TryConvertToTruncating<TOther>(F32 value, [MaybeNullWhen(false)] out TOther result)
    {
        return TryConvertTo(value, out result);
    }

    static bool INumberBase<F32>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out F32 result)
    {
        var success = double.TryParse(s, style, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static bool INumberBase<F32>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out F32 result)
    {
        var success = double.TryParse(s, style, provider, out var doubleResult);
        result = FromDouble(doubleResult);
        return success;
    }

    static int INumberBase<F32>.Radix => 2;
}
