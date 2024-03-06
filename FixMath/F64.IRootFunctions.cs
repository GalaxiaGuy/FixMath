using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F64 : IRootFunctions<F64>
{
    public static F64 Cbrt(F64 x) => RootN(x, 3);

    public static F64 Hypot(F64 x, F64 y) => Sqrt(x * x + y * y);

    public static F64 RootN(F64 x, int n) => Pow(x, F64.One / F64.FromInt(n));
}
