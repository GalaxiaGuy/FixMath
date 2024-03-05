using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F64 : IBinaryNumber<F64>
{
    public static F64 operator &(F64 left, F64 right) => FromRaw(left.Raw & right.Raw);

    public static F64 operator |(F64 left, F64 right) => FromRaw(left.Raw | right.Raw);

    public static F64 operator ^(F64 left, F64 right) => FromRaw(left.Raw ^ right.Raw);

    public static F64 operator ~(F64 value) => FromRaw(~value.Raw);

    public static bool IsPow2(F64 value)
    {
        return IsInteger(value) && long.IsPow2(value.Raw >> 32);
    }
}
