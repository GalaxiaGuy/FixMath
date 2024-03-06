using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F32 : IBinaryNumber<F32>
{
    public static F32 operator &(F32 left, F32 right) => FromRaw(left.Raw & right.Raw);

    public static F32 operator |(F32 left, F32 right) => FromRaw(left.Raw | right.Raw);

    public static F32 operator ^(F32 left, F32 right) => FromRaw(left.Raw ^ right.Raw);

    public static F32 operator ~(F32 value) => FromRaw(~value.Raw);

    public static bool IsPow2(F32 value)
    {
        return IsInteger(value) && long.IsPow2(value.Raw >> 16);
    }
}
